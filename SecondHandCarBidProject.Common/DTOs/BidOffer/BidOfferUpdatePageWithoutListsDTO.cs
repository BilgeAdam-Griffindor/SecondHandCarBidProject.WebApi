using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecondHandCarBidProject.Common.DTOs.BidOffer
{
    public record BidOfferUpdatePageWithoutListsDTO
    (
        Guid Id,
        decimal OfferAmount,
        Guid BaseUserId,
        Guid BidId,
        string Explanation
    );
}
