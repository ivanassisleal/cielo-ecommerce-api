using Cielo.eCommerce.Api.Entities.Enum;

namespace Cielo.eCommerce.Api.Services
{
    public class ServiceBase
    {
        private EnvironmentEnum _environmentEnum;

        public ServiceBase(EnvironmentEnum environmentEnum)
        {
            _environmentEnum = environmentEnum;
        }

        protected string GetBaseAddressApi
        {
            get
            {
                string resource = "";
                switch (_environmentEnum)
                {
                    case EnvironmentEnum.Sandbox:
                        resource = "https://apisandbox.cieloecommerce.cielo.com.br";
                        break;
                    case EnvironmentEnum.Production:
                        resource = "https://api.cieloecommerce.cielo.com.br";
                        break;
                    default:
                        resource = "https://apisandbox.cieloecommerce.cielo.com.br";
                        break;
                }

                return resource;
            }
        }

        protected string GetBaseAddressApiQuery
        {
            get
            {
                string resource = "";
                switch (_environmentEnum)
                {
                    case EnvironmentEnum.Sandbox:
                        resource = "https://apiquerysandbox.cieloecommerce.cielo.com.br";
                        break;
                    case EnvironmentEnum.Production:
                        resource = "https://apiquery.cieloecommerce.cielo.com.br";
                        break;
                    default:
                        resource = "https://apiquerysandbox.cieloecommerce.cielo.com.br";
                        break;
                }

                return resource;
            }
        }
    }
}
