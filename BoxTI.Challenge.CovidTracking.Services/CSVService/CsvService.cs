using BoxTI.Challenge.CovidTracking.Models.Entities;
using CsvHelper;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace BoxTI.Challenge.CovidTracking.Services.CSVService
{
    public class CsvService : ICsvService
    {
        public async Task<string> exportCountriesRegistryToCsv(CountryRegistry countryToExport)
        {
            var path = Path.Combine(AppContext.BaseDirectory, $"{countryToExport.Name}-registry-export.csv");
            var crList = new List<CountryRegistry> { countryToExport };

            await using (var writer = new StreamWriter(path))
            {
                await using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
                {
                    await csv.WriteRecordsAsync(crList);
                    await csv.FlushAsync();
                    await writer.FlushAsync();
                    return $"CSV salvo com sucesso no caminho: {path}";
                }
            }
        }
    }
}
