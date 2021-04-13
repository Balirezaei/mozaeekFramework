using System.Linq;
using MozaeekCore.ApplicationService.Contract;
using MozaeekCore.Domain;

namespace MozaeekCore.Mapper
{
    public static class BasicInfoProfile
    {
        public static LabelDto GetLabelDto(this Label domain)
        {
            return new LabelDto()
            {
                Id = domain.Id,
                Title = domain.Title,
                ParentId = domain.ParentId
            };
        }
        public static LabelDto GetLabelDtoNoParent(this Label domain)
        {
            return new LabelDto()
            {
                Id = domain.Id,
                Title = domain.Title
            };
        }
   
        
    }
}