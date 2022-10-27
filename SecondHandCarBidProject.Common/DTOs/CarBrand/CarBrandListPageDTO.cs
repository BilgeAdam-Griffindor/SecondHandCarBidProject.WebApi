using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecondHandCarBidProject.Common.DTOs.CarBrand
{
    public record CarBrandListPageDTO(
        List<CarBrandListTableRow> TableRows,
        int maxPages
        );
}
