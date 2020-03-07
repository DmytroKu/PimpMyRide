using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlazorApp
{
    public class Text
    {
        public List<string> Value { get; private set; }

        public Text()
        {
            Value = new List<string>();
        }

        public async Task Run(Func<Task> refreshUi)
        {
            while (true)
            {
                await Task.Delay(1000);
                Value.Add("line");
                await refreshUi();
            }
        }
    }
}