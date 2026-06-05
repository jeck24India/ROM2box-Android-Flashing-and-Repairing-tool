namespace mtkclient.library.xflash
{
    internal class MtkWatchdogValueCalculatorService
    {
        public static uint CalculateDisable(uint wdgAddress, uint hardwareCode)
        {
            switch (wdgAddress)
            {
                case 268464128u:
                    return 570425444u;
                case 270606336u:
                    return 570425344u;
                case 270602240u:
                    return 570425444u;
                case 268465152u:
                    return 570425344u;
                case 3221225472u:
                    return 0u;
                case 8704u:
                    switch (hardwareCode)
                    {
                        case 25173u:
                            return 1881014272u;
                        default:
                            return 1879199744u;
                        case 25169u:
                        case 25878u:
                            return 2147680256u;
                        case 25206u:
                        case 33123u:
                            return 1628176384u;
                    }
                default:
                    return 570425444u;
            }
        }
    }
}
