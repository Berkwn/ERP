using Ardalis.SmartEnum;

namespace ERPServer.Domain.Enums
{
    public class ProductTypeEnum : SmartEnum<ProductTypeEnum>
    {
        public static readonly ProductTypeEnum product=new ProductTypeEnum("Mamül",1);
        public static readonly ProductTypeEnum SemiProduct = new ProductTypeEnum("Yarı mamül", 2);
        public ProductTypeEnum(string name, int value) : base(name, value)
        {
        }
    }
}
