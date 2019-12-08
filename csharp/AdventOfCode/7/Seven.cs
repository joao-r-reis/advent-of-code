using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AdventOfCode.IntCodeComputer;
using Combinatorics.Collections;

namespace AdventOfCode._7
{
    public class Seven : BaseRunnable
    {
        private const int TimeoutMs = 60000;

        private readonly bool _feedbackLoop;
        private readonly int _phaseLowerBound = 0;

        public Seven() : this(false)
        {
        }

        protected Seven(bool feedbackLoop)
        {
            _feedbackLoop = feedbackLoop;

            if (_feedbackLoop)
            {
                _phaseLowerBound = 5;
            }
        }

        public override string Run(StreamReader reader)
        {
            var data = Parse(reader);
            return ComputeMaxSignal(data).ToString();
        }

        public int ComputeMaxSignal(int[] data)
        {
            var permutations = new Permutations<int>(Enumerable.Range(_phaseLowerBound, 5).ToList(), GenerateOption.WithoutRepetition);
            var outputs = new ConcurrentQueue<int>();

            Parallel.ForEach(
                permutations.Select((p, index) => (p, index)),
                phaseSettings =>
                {
                    outputs.Enqueue(ComputeSignal(phaseSettings.Item1, data));
                });

            return outputs.Max();
        }

        public int ComputeSignal(IList<int> phaseSettings, int[] data)
        {
            var amplifiers = new IIntCodeProgram[phaseSettings.Count];
            var firstInput = new BlockingCollection<int>();

            for (var i = 0; i < amplifiers.Length; i++)
            {
                var input = i == 0 ? firstInput : amplifiers[i - 1].Output;
                input.Add(phaseSettings[i]);

                if (_feedbackLoop && i == amplifiers.Length - 1)
                {
                    amplifiers[i] = IntCodeProgram.NewDay7PointFive(input, firstInput);
                }
                else
                {
                    amplifiers[i] = IntCodeProgram.NewDay5PointFive(input);
                }
            }

            var tasks = amplifiers.Select(program =>
                Task.Factory.StartNew(() => program.Compute(data.ToArray()), TaskCreationOptions.LongRunning));

            firstInput.Add(0);

            Task.WhenAll(tasks).Wait(TimeoutMs);

            var took = amplifiers.Last().Output.TryTake(out var signal);

            if (!took)
            {
                throw new InvalidOperationException("No output found.");
            }

            if (amplifiers.Last().Output.Count != 0)
            {
                throw new InvalidOperationException("There's still output in the last amplifier.");
            }

            return signal;
        }

        private int[] Parse(StreamReader reader)
        {
            var text = reader.ReadToEnd();
            return text.Split(",").Select(int.Parse).ToArray();
        }
    }
}