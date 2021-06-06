using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Stripe;
using Microsoft.Extensions.Configuration;

namespace Govimithuro.Services
{
    public class MakePayment
    {
        private IConfiguration _configuration;

        public MakePayment(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public static bool paymentStatus = false;
        public async Task PayAsync(string cardNo, int month, int year, string cvv, int totalPrice)
        {
            try
            {
                StripeConfiguration.ApiKey = "sk_test_51IWOzDGYDMIyeu07oFfINh8c6mroUIYKetZCHTkBmTbgEuZ1PvyF8rEvbFIfHueIc0OcjfeCFrEfrFqvr7g5BEVH00dtxFqW9C";
                var optionstoken = new TokenCreateOptions
                {
                    Card = new TokenCardOptions
                    {
                        Number = cardNo,
                        ExpMonth = month,
                        ExpYear = year,
                        Cvc = cvv,
                    }
                };

                var servicetoken = new TokenService();
                Token stripetoken = await servicetoken.CreateAsync(optionstoken);

                var options = new ChargeCreateOptions
                {
                    Amount = totalPrice,
                    Currency = "lkr",
                    Description = "test",
                    Source = stripetoken.Id
                };

                var service = new ChargeService();
                Charge charge = await service.CreateAsync(options);

                if (charge.Paid)
                {
                    paymentStatus = true;
                }

            }
            catch (Exception)
            {
                throw;//return e.Message;
            }
        }
    }
}
