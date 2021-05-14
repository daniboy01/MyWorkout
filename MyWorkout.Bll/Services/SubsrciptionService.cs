using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.EntityFrameworkCore;
using MyWorkout.Dal;
using MyWorkout.Dal.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWorkout.Bll.Services
{
    public class SubsrciptionService
    {
        private readonly MyWorkoutDbContext dbContext;
        private readonly IEmailSender emailSender;

        public SubsrciptionService( MyWorkoutDbContext dbContext, IEmailSender emailSender )
        {
            this.dbContext = dbContext;
            this.emailSender = emailSender;
        }

        public List<Subscription> GetAll()
        {
            return dbContext.Subscriptions.Include(s => s.User).ToList();
        }

        public Subscription CreateNewSubscription(int userID)
        {
            var user = dbContext.Users.Single(u => u.Id == userID);

            var newSub = new Subscription
            {
                UserId = user.Id,
                User = user,
            };
            dbContext.Subscriptions.Add(newSub);
            dbContext.SaveChanges();

            return newSub;
        }

        public async Task NotifySubscriptedUsers(string text, string htmlMessage)
        {
            var subscriptions = GetAll();


            foreach(var sub in subscriptions)
            {
                await emailSender.SendEmailAsync(sub.User.Email, text, htmlMessage);
            }
        }
    }
}
