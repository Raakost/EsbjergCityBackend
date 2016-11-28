using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.Entities;

namespace DataAccessLayer.Context
{
    public class DbInit : CreateDatabaseIfNotExists<EsbjergCityContext>
    {
        protected override void Seed(EsbjergCityContext db)
        {
            //GIFTCARD
            var g1 = new GiftCard { Amount = 200.00, CardNumber = "123" };
            var g2 = new GiftCard { Amount = 500.00, CardNumber = "789" };
            var g3 = new GiftCard { Amount = 1000.00, CardNumber = "456" };

            //ORDER
            var o1 = new Order { DateOfPurchase = DateTime.Now, GiftCards = new List<GiftCard> { g1, g2 } };
            var o2 = new Order { DateOfPurchase = DateTime.Now, GiftCards = new List<GiftCard> { g3 } };

            //ADMIN
            var a1 = new Admin
            {
                Email = "admin@esbjerg.dk",
                Firstname = "Brigitta",
                Lastname = "Jensen",
                Password = "pw"
            };

            //EVENT
            var e1 = new Event
            {
                DateOfEvent = DateTime.Now,
                Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Proin porttitor maximus lobortis. Etiam hendrerit et nisl id fringilla. Curabitur sit amet molestie purus. Nullam faucibus at neque malesuada volutpat. Fusce lorem ipsum, auctor sit amet neque sed, euismod sagittis justo. Pellentesque et massa a nibh iaculis tincidunt. Nullam sed metus lacinia, mattis ex nec, placerat nunc. Pellentesque lacinia dui nec eros gravida, eu elementum tortor finibus. Mauris semper dolor in ipsum posuere finibus. Sed placerat, sapien id pharetra maximus, mauris sapien condimentum nunc, sit amet finibus ipsum ante molestie urna." +
                              "Fusce sem lacus, imperdiet tincidunt varius a, iaculis luctus tortor. Nullam hendrerit, arcu at volutpat porttitor, ex ex pretium neque, quis semper nunc turpis sed sem. Nunc eget aliquet elit. Suspendisse tempus venenatis mollis. Maecenas et lobortis dolor, tempor suscipit libero. Morbi nec mauris lacinia felis tincidunt blandit. Morbi accumsan lacinia tempor. Mauris sollicitudin auctor nibh eget ultricies. Nam tincidunt volutpat turpis, id dignissim elit eleifend ut. Praesent et sollicitudin lorem. Ut vitae felis risus. Sed sed tortor magna. Nulla imperdiet sagittis ante. Aliquam nec ornare quam.",
                Title = "Title of event 1",
                Img = "http://lorempixel.com/300/300"
            };

            var e2 = new Event
            {
                DateOfEvent = DateTime.Now.AddMonths(+1),
                Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Proin porttitor maximus lobortis. Etiam hendrerit et nisl id fringilla. Curabitur sit amet molestie purus. Nullam faucibus at neque malesuada volutpat. Fusce lorem ipsum, auctor sit amet neque sed, euismod sagittis justo. Pellentesque et massa a nibh iaculis tincidunt. Nullam sed metus lacinia, mattis ex nec, placerat nunc. Pellentesque lacinia dui nec eros gravida, eu elementum tortor finibus. Mauris semper dolor in ipsum posuere finibus. Sed placerat, sapien id pharetra maximus, mauris sapien condimentum nunc, sit amet finibus ipsum ante molestie urna." +
                              "Fusce sem lacus, imperdiet tincidunt varius a, iaculis luctus tortor. Nullam hendrerit, arcu at volutpat porttitor, ex ex pretium neque, quis semper nunc turpis sed sem. Nunc eget aliquet elit. Suspendisse tempus venenatis mollis. Maecenas et lobortis dolor, tempor suscipit libero. Morbi nec mauris lacinia felis tincidunt blandit. Morbi accumsan lacinia tempor. Mauris sollicitudin auctor nibh eget ultricies. Nam tincidunt volutpat turpis, id dignissim elit eleifend ut. Praesent et sollicitudin lorem. Ut vitae felis risus. Sed sed tortor magna. Nulla imperdiet sagittis ante. Aliquam nec ornare quam.",
                Title = "Title of event 2",
                Img = "http://lorempixel.com/300/300"
            };

            var e3 = new Event
            {
                DateOfEvent = DateTime.Now.AddMonths(+2),
                Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Proin porttitor maximus lobortis. Etiam hendrerit et nisl id fringilla. Curabitur sit amet molestie purus. Nullam faucibus at neque malesuada volutpat. Fusce lorem ipsum, auctor sit amet neque sed, euismod sagittis justo. Pellentesque et massa a nibh iaculis tincidunt. Nullam sed metus lacinia, mattis ex nec, placerat nunc. Pellentesque lacinia dui nec eros gravida, eu elementum tortor finibus. Mauris semper dolor in ipsum posuere finibus. Sed placerat, sapien id pharetra maximus, mauris sapien condimentum nunc, sit amet finibus ipsum ante molestie urna." +
                              "Fusce sem lacus, imperdiet tincidunt varius a, iaculis luctus tortor. Nullam hendrerit, arcu at volutpat porttitor, ex ex pretium neque, quis semper nunc turpis sed sem. Nunc eget aliquet elit. Suspendisse tempus venenatis mollis. Maecenas et lobortis dolor, tempor suscipit libero. Morbi nec mauris lacinia felis tincidunt blandit. Morbi accumsan lacinia tempor. Mauris sollicitudin auctor nibh eget ultricies. Nam tincidunt volutpat turpis, id dignissim elit eleifend ut. Praesent et sollicitudin lorem. Ut vitae felis risus. Sed sed tortor magna. Nulla imperdiet sagittis ante. Aliquam nec ornare quam.",
                Title = "Title of event 3",
                Img = "http://lorempixel.com/300/300"
            };

            var e4 = new Event
            {
                DateOfEvent = DateTime.Now.AddMonths(+3),
                Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Proin porttitor maximus lobortis. Etiam hendrerit et nisl id fringilla. Curabitur sit amet molestie purus. Nullam faucibus at neque malesuada volutpat. Fusce lorem ipsum, auctor sit amet neque sed, euismod sagittis justo. Pellentesque et massa a nibh iaculis tincidunt. Nullam sed metus lacinia, mattis ex nec, placerat nunc. Pellentesque lacinia dui nec eros gravida, eu elementum tortor finibus. Mauris semper dolor in ipsum posuere finibus. Sed placerat, sapien id pharetra maximus, mauris sapien condimentum nunc, sit amet finibus ipsum ante molestie urna." +
                              "Fusce sem lacus, imperdiet tincidunt varius a, iaculis luctus tortor. Nullam hendrerit, arcu at volutpat porttitor, ex ex pretium neque, quis semper nunc turpis sed sem. Nunc eget aliquet elit. Suspendisse tempus venenatis mollis. Maecenas et lobortis dolor, tempor suscipit libero. Morbi nec mauris lacinia felis tincidunt blandit. Morbi accumsan lacinia tempor. Mauris sollicitudin auctor nibh eget ultricies. Nam tincidunt volutpat turpis, id dignissim elit eleifend ut. Praesent et sollicitudin lorem. Ut vitae felis risus. Sed sed tortor magna. Nulla imperdiet sagittis ante. Aliquam nec ornare quam.",
                Title = "Title of event 4",
                Img = "http://lorempixel.com/300/300"
            };

            var e5 = new Event
            {
                DateOfEvent = DateTime.Now.AddMonths(+4),
                Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Proin porttitor maximus lobortis. Etiam hendrerit et nisl id fringilla. Curabitur sit amet molestie purus. Nullam faucibus at neque malesuada volutpat. Fusce lorem ipsum, auctor sit amet neque sed, euismod sagittis justo. Pellentesque et massa a nibh iaculis tincidunt. Nullam sed metus lacinia, mattis ex nec, placerat nunc. Pellentesque lacinia dui nec eros gravida, eu elementum tortor finibus. Mauris semper dolor in ipsum posuere finibus. Sed placerat, sapien id pharetra maximus, mauris sapien condimentum nunc, sit amet finibus ipsum ante molestie urna." +
                              "Fusce sem lacus, imperdiet tincidunt varius a, iaculis luctus tortor. Nullam hendrerit, arcu at volutpat porttitor, ex ex pretium neque, quis semper nunc turpis sed sem. Nunc eget aliquet elit. Suspendisse tempus venenatis mollis. Maecenas et lobortis dolor, tempor suscipit libero. Morbi nec mauris lacinia felis tincidunt blandit. Morbi accumsan lacinia tempor. Mauris sollicitudin auctor nibh eget ultricies. Nam tincidunt volutpat turpis, id dignissim elit eleifend ut. Praesent et sollicitudin lorem. Ut vitae felis risus. Sed sed tortor magna. Nulla imperdiet sagittis ante. Aliquam nec ornare quam.",
                Title = "Title of event 5",
                Img = "http://lorempixel.com/300/300"
            };

            var e6 = new Event
            {
                DateOfEvent = DateTime.Now.AddMonths(+5),
                Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Proin porttitor maximus lobortis. Etiam hendrerit et nisl id fringilla. Curabitur sit amet molestie purus. Nullam faucibus at neque malesuada volutpat. Fusce lorem ipsum, auctor sit amet neque sed, euismod sagittis justo. Pellentesque et massa a nibh iaculis tincidunt. Nullam sed metus lacinia, mattis ex nec, placerat nunc. Pellentesque lacinia dui nec eros gravida, eu elementum tortor finibus. Mauris semper dolor in ipsum posuere finibus. Sed placerat, sapien id pharetra maximus, mauris sapien condimentum nunc, sit amet finibus ipsum ante molestie urna." +
                              "Fusce sem lacus, imperdiet tincidunt varius a, iaculis luctus tortor. Nullam hendrerit, arcu at volutpat porttitor, ex ex pretium neque, quis semper nunc turpis sed sem. Nunc eget aliquet elit. Suspendisse tempus venenatis mollis. Maecenas et lobortis dolor, tempor suscipit libero. Morbi nec mauris lacinia felis tincidunt blandit. Morbi accumsan lacinia tempor. Mauris sollicitudin auctor nibh eget ultricies. Nam tincidunt volutpat turpis, id dignissim elit eleifend ut. Praesent et sollicitudin lorem. Ut vitae felis risus. Sed sed tortor magna. Nulla imperdiet sagittis ante. Aliquam nec ornare quam.",
                Title = "Title of event 6",
                Img = "http://lorempixel.com/300/300"
            };

            //CUSTOMER
            var c1 = new Customer
            {
                Firstname = "jens",
                Lastname = "bobbo",
                City = "Esbjerg",
                Zipcode = 6700,
                Street = "EsbjergGade",
                StreetNumber = 1,
                Email = "jens@esbjerg.dk",
                Password = "",
                Orders = new List<Order> { o1 }
            };

            var c2 = new Customer
            {
                Firstname = "Hans",
                Lastname = "Hansen",
                City = "Esbjerg",
                Zipcode = 6700,
                Street = "EsbjergGade",
                StreetNumber = 2,
                Email = "hans@esbjerg.dk",
                Password = "",
                Orders = new List<Order> { o2 }
            };

            var c3 = new Customer
            {
                Firstname = "Lars",
                Lastname = "Larsen",
                City = "Esbjerg",
                Zipcode = 6700,
                Street = "EsbjergGade",
                StreetNumber = 3,
                Email = "lars@esbjerg.dk",
                Password = "",
                Orders = new List<Order> { }
            };

            //SEED DB
            db.Customers.Add(c1);
            db.Customers.Add(c2);
            db.Customers.Add(c3);
            db.Events.Add(e1);
            db.Events.Add(e2);
            db.Events.Add(e3);
            db.Events.Add(e4);
            db.Events.Add(e5);
            db.Events.Add(e6);
            db.Admins.Add(a1);

            base.Seed(db);
        }
    }
}
