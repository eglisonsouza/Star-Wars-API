using System.Collections.Generic;

namespace StarWars.API.Domain.ViewModels
{
    public class ResultAPIViewModel<ViewModel>
    {
        public string Next { get; set; }
        public IReadOnlyList<ViewModel> Results { get; set; }
    }
}