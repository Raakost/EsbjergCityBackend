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
            var g3 = new GiftCard { Amount = 100.00, CardNumber = "456" };
            var g4 = new GiftCard { Amount = 1500.00, CardNumber = "777" };
            var g5 = new GiftCard { Amount = 400.00, CardNumber = "888" };
            var g6 = new GiftCard { Amount = 800.00, CardNumber = "999" };

            //ORDER
            var o1 = new Order { IsCompleted = false, DateOfPurchase = DateTime.Now, GiftCards = new List<GiftCard> { g1, g2 } };
            var o2 = new Order { IsCompleted = false, DateOfPurchase = DateTime.Now, GiftCards = new List<GiftCard> { g3 } };
            var o3 = new Order { IsCompleted = false, DateOfPurchase = DateTime.Now, GiftCards = new List<GiftCard> { g4 } };
            var o4 = new Order { IsCompleted = false, DateOfPurchase = DateTime.Now, GiftCards = new List<GiftCard> { g5 } };
            var o5 = new Order { IsCompleted = false, DateOfPurchase = DateTime.Now, GiftCards = new List<GiftCard> { g6 } };            

            //EVENT
            var e1 = new Event
            {
                DateOfEvent = DateTime.Now.AddYears(1),
                Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Proin porttitor maximus lobortis. Etiam hendrerit et nisl id fringilla. Curabitur sit amet molestie purus. Nullam faucibus at neque malesuada volutpat. Fusce lorem ipsum, auctor sit amet neque sed, euismod sagittis justo. Pellentesque et massa a nibh iaculis tincidunt. Nullam sed metus lacinia, mattis ex nec, placerat nunc. Pellentesque lacinia dui nec eros gravida, eu elementum tortor finibus. Mauris semper dolor in ipsum posuere finibus. Sed placerat, sapien id pharetra maximus, mauris sapien condimentum nunc, sit amet finibus ipsum ante molestie urna." +
                              "Fusce sem lacus, imperdiet tincidunt varius a, iaculis luctus tortor. Nullam hendrerit, arcu at volutpat porttitor, ex ex pretium neque, quis semper nunc turpis sed sem. Nunc eget aliquet elit. Suspendisse tempus venenatis mollis. Maecenas et lobortis dolor, tempor suscipit libero. Morbi nec mauris lacinia felis tincidunt blandit. Morbi accumsan lacinia tempor. Mauris sollicitudin auctor nibh eget ultricies. Nam tincidunt volutpat turpis, id dignissim elit eleifend ut. Praesent et sollicitudin lorem. Ut vitae felis risus. Sed sed tortor magna. Nulla imperdiet sagittis ante. Aliquam nec ornare quam.",
                Title = "Lorem ipsum",
                Img = "/Content/Images/1.jpg"
            };

            var e2 = new Event
            {
                DateOfEvent = DateTime.Now.AddYears(1),
                Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Proin porttitor maximus lobortis. Etiam hendrerit et nisl id fringilla. Curabitur sit amet molestie purus. Nullam faucibus at neque malesuada volutpat. Fusce lorem ipsum, auctor sit amet neque sed, euismod sagittis justo. Pellentesque et massa a nibh iaculis tincidunt. Nullam sed metus lacinia, mattis ex nec, placerat nunc. Pellentesque lacinia dui nec eros gravida, eu elementum tortor finibus. Mauris semper dolor in ipsum posuere finibus. Sed placerat, sapien id pharetra maximus, mauris sapien condimentum nunc, sit amet finibus ipsum ante molestie urna." +
                              "Fusce sem lacus, imperdiet tincidunt varius a, iaculis luctus tortor. Nullam hendrerit, arcu at volutpat porttitor, ex ex pretium neque, quis semper nunc turpis sed sem. Nunc eget aliquet elit. Suspendisse tempus venenatis mollis. Maecenas et lobortis dolor, tempor suscipit libero. Morbi nec mauris lacinia felis tincidunt blandit. Morbi accumsan lacinia tempor. Mauris sollicitudin auctor nibh eget ultricies. Nam tincidunt volutpat turpis, id dignissim elit eleifend ut. Praesent et sollicitudin lorem. Ut vitae felis risus. Sed sed tortor magna. Nulla imperdiet sagittis ante. Aliquam nec ornare quam.",
                Title = "Lorem ipsum",
                Img = "/Content/Images/2.jpg"
            };

            var e3 = new Event
            {
                DateOfEvent = DateTime.Now.AddYears(1),
                Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Proin porttitor maximus lobortis. Etiam hendrerit et nisl id fringilla. Curabitur sit amet molestie purus. Nullam faucibus at neque malesuada volutpat. Fusce lorem ipsum, auctor sit amet neque sed, euismod sagittis justo. Pellentesque et massa a nibh iaculis tincidunt. Nullam sed metus lacinia, mattis ex nec, placerat nunc. Pellentesque lacinia dui nec eros gravida, eu elementum tortor finibus. Mauris semper dolor in ipsum posuere finibus. Sed placerat, sapien id pharetra maximus, mauris sapien condimentum nunc, sit amet finibus ipsum ante molestie urna." +
                              "Fusce sem lacus, imperdiet tincidunt varius a, iaculis luctus tortor. Nullam hendrerit, arcu at volutpat porttitor, ex ex pretium neque, quis semper nunc turpis sed sem. Nunc eget aliquet elit. Suspendisse tempus venenatis mollis. Maecenas et lobortis dolor, tempor suscipit libero. Morbi nec mauris lacinia felis tincidunt blandit. Morbi accumsan lacinia tempor. Mauris sollicitudin auctor nibh eget ultricies. Nam tincidunt volutpat turpis, id dignissim elit eleifend ut. Praesent et sollicitudin lorem. Ut vitae felis risus. Sed sed tortor magna. Nulla imperdiet sagittis ante. Aliquam nec ornare quam.",
                Title = "Lorem ipsum",
                Img = "/Content/Images/3.jpg"
            };

            var e4 = new Event
            {
                DateOfEvent = DateTime.Now.AddYears(1),
                Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Proin porttitor maximus lobortis. Etiam hendrerit et nisl id fringilla. Curabitur sit amet molestie purus. Nullam faucibus at neque malesuada volutpat. Fusce lorem ipsum, auctor sit amet neque sed, euismod sagittis justo. Pellentesque et massa a nibh iaculis tincidunt. Nullam sed metus lacinia, mattis ex nec, placerat nunc. Pellentesque lacinia dui nec eros gravida, eu elementum tortor finibus. Mauris semper dolor in ipsum posuere finibus. Sed placerat, sapien id pharetra maximus, mauris sapien condimentum nunc, sit amet finibus ipsum ante molestie urna." +
                              "Fusce sem lacus, imperdiet tincidunt varius a, iaculis luctus tortor. Nullam hendrerit, arcu at volutpat porttitor, ex ex pretium neque, quis semper nunc turpis sed sem. Nunc eget aliquet elit. Suspendisse tempus venenatis mollis. Maecenas et lobortis dolor, tempor suscipit libero. Morbi nec mauris lacinia felis tincidunt blandit. Morbi accumsan lacinia tempor. Mauris sollicitudin auctor nibh eget ultricies. Nam tincidunt volutpat turpis, id dignissim elit eleifend ut. Praesent et sollicitudin lorem. Ut vitae felis risus. Sed sed tortor magna. Nulla imperdiet sagittis ante. Aliquam nec ornare quam.",
                Title = "Lorem ipsum",
                Img = "/Content/Images/4.jpg"
            };

            var e5 = new Event
            {
                DateOfEvent = DateTime.Now.AddYears(1),
                Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Proin porttitor maximus lobortis. Etiam hendrerit et nisl id fringilla. Curabitur sit amet molestie purus. Nullam faucibus at neque malesuada volutpat. Fusce lorem ipsum, auctor sit amet neque sed, euismod sagittis justo. Pellentesque et massa a nibh iaculis tincidunt. Nullam sed metus lacinia, mattis ex nec, placerat nunc. Pellentesque lacinia dui nec eros gravida, eu elementum tortor finibus. Mauris semper dolor in ipsum posuere finibus. Sed placerat, sapien id pharetra maximus, mauris sapien condimentum nunc, sit amet finibus ipsum ante molestie urna." +
                              "Fusce sem lacus, imperdiet tincidunt varius a, iaculis luctus tortor. Nullam hendrerit, arcu at volutpat porttitor, ex ex pretium neque, quis semper nunc turpis sed sem. Nunc eget aliquet elit. Suspendisse tempus venenatis mollis. Maecenas et lobortis dolor, tempor suscipit libero. Morbi nec mauris lacinia felis tincidunt blandit. Morbi accumsan lacinia tempor. Mauris sollicitudin auctor nibh eget ultricies. Nam tincidunt volutpat turpis, id dignissim elit eleifend ut. Praesent et sollicitudin lorem. Ut vitae felis risus. Sed sed tortor magna. Nulla imperdiet sagittis ante. Aliquam nec ornare quam.",
                Title = "Lorem ipsum",
                Img = "/Content/Images/5.jpg"
            };

            var e6 = new Event
            {
                DateOfEvent = DateTime.Now.AddYears(1),
                Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Proin porttitor maximus lobortis. Etiam hendrerit et nisl id fringilla. Curabitur sit amet molestie purus. Nullam faucibus at neque malesuada volutpat. Fusce lorem ipsum, auctor sit amet neque sed, euismod sagittis justo. Pellentesque et massa a nibh iaculis tincidunt. Nullam sed metus lacinia, mattis ex nec, placerat nunc. Pellentesque lacinia dui nec eros gravida, eu elementum tortor finibus. Mauris semper dolor in ipsum posuere finibus. Sed placerat, sapien id pharetra maximus, mauris sapien condimentum nunc, sit amet finibus ipsum ante molestie urna." +
                              "Fusce sem lacus, imperdiet tincidunt varius a, iaculis luctus tortor. Nullam hendrerit, arcu at volutpat porttitor, ex ex pretium neque, quis semper nunc turpis sed sem. Nunc eget aliquet elit. Suspendisse tempus venenatis mollis. Maecenas et lobortis dolor, tempor suscipit libero. Morbi nec mauris lacinia felis tincidunt blandit. Morbi accumsan lacinia tempor. Mauris sollicitudin auctor nibh eget ultricies. Nam tincidunt volutpat turpis, id dignissim elit eleifend ut. Praesent et sollicitudin lorem. Ut vitae felis risus. Sed sed tortor magna. Nulla imperdiet sagittis ante. Aliquam nec ornare quam.",
                Title = "Lorem ipsum",
                Img = "/Content/Images/6.jpg"
            };

            var e7 = new Event
            {
                DateOfEvent = DateTime.Now.AddYears(1),
                Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Proin porttitor maximus lobortis. Etiam hendrerit et nisl id fringilla. Curabitur sit amet molestie purus. Nullam faucibus at neque malesuada volutpat. Fusce lorem ipsum, auctor sit amet neque sed, euismod sagittis justo. Pellentesque et massa a nibh iaculis tincidunt. Nullam sed metus lacinia, mattis ex nec, placerat nunc. Pellentesque lacinia dui nec eros gravida, eu elementum tortor finibus. Mauris semper dolor in ipsum posuere finibus. Sed placerat, sapien id pharetra maximus, mauris sapien condimentum nunc, sit amet finibus ipsum ante molestie urna." +
                              "Fusce sem lacus, imperdiet tincidunt varius a, iaculis luctus tortor. Nullam hendrerit, arcu at volutpat porttitor, ex ex pretium neque, quis semper nunc turpis sed sem. Nunc eget aliquet elit. Suspendisse tempus venenatis mollis. Maecenas et lobortis dolor, tempor suscipit libero. Morbi nec mauris lacinia felis tincidunt blandit. Morbi accumsan lacinia tempor. Mauris sollicitudin auctor nibh eget ultricies. Nam tincidunt volutpat turpis, id dignissim elit eleifend ut. Praesent et sollicitudin lorem. Ut vitae felis risus. Sed sed tortor magna. Nulla imperdiet sagittis ante. Aliquam nec ornare quam.",
                Title = "Lorem ipsum",
                Img = "/Content/Images/7.jpg"
            };

            var e8 = new Event
            {
                DateOfEvent = DateTime.Now.AddYears(1),
                Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Proin porttitor maximus lobortis. Etiam hendrerit et nisl id fringilla. Curabitur sit amet molestie purus. Nullam faucibus at neque malesuada volutpat. Fusce lorem ipsum, auctor sit amet neque sed, euismod sagittis justo. Pellentesque et massa a nibh iaculis tincidunt. Nullam sed metus lacinia, mattis ex nec, placerat nunc. Pellentesque lacinia dui nec eros gravida, eu elementum tortor finibus. Mauris semper dolor in ipsum posuere finibus. Sed placerat, sapien id pharetra maximus, mauris sapien condimentum nunc, sit amet finibus ipsum ante molestie urna." +
                             "Fusce sem lacus, imperdiet tincidunt varius a, iaculis luctus tortor. Nullam hendrerit, arcu at volutpat porttitor, ex ex pretium neque, quis semper nunc turpis sed sem. Nunc eget aliquet elit. Suspendisse tempus venenatis mollis. Maecenas et lobortis dolor, tempor suscipit libero. Morbi nec mauris lacinia felis tincidunt blandit. Morbi accumsan lacinia tempor. Mauris sollicitudin auctor nibh eget ultricies. Nam tincidunt volutpat turpis, id dignissim elit eleifend ut. Praesent et sollicitudin lorem. Ut vitae felis risus. Sed sed tortor magna. Nulla imperdiet sagittis ante. Aliquam nec ornare quam.",
                Title = "Lorem ipsum",
                Img = "/Content/Images/8.jpg"
            };

            var e9 = new Event
            {
                DateOfEvent = DateTime.Now.AddYears(1),
                Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Proin porttitor maximus lobortis. Etiam hendrerit et nisl id fringilla. Curabitur sit amet molestie purus. Nullam faucibus at neque malesuada volutpat. Fusce lorem ipsum, auctor sit amet neque sed, euismod sagittis justo. Pellentesque et massa a nibh iaculis tincidunt. Nullam sed metus lacinia, mattis ex nec, placerat nunc. Pellentesque lacinia dui nec eros gravida, eu elementum tortor finibus. Mauris semper dolor in ipsum posuere finibus. Sed placerat, sapien id pharetra maximus, mauris sapien condimentum nunc, sit amet finibus ipsum ante molestie urna." +
                          "Fusce sem lacus, imperdiet tincidunt varius a, iaculis luctus tortor. Nullam hendrerit, arcu at volutpat porttitor, ex ex pretium neque, quis semper nunc turpis sed sem. Nunc eget aliquet elit. Suspendisse tempus venenatis mollis. Maecenas et lobortis dolor, tempor suscipit libero. Morbi nec mauris lacinia felis tincidunt blandit. Morbi accumsan lacinia tempor. Mauris sollicitudin auctor nibh eget ultricies. Nam tincidunt volutpat turpis, id dignissim elit eleifend ut. Praesent et sollicitudin lorem. Ut vitae felis risus. Sed sed tortor magna. Nulla imperdiet sagittis ante. Aliquam nec ornare quam.",
                Title = "Lorem ipsum",
                Img = "/Content/Images/9.jpg"
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
                Orders = new List<Order> { o2 }
            };

            var c3 = new Customer
            {
                Firstname = "Jørgen",
                Lastname = "Hansen",
                City = "Esbjerg",
                Zipcode = 6700,
                Street = "EsbjergGade",
                StreetNumber = 2,
                Email = "jørgen@esbjerg.dk",
                Orders = new List<Order> { o3, o4 }
            };

            var c4 = new Customer
            {
                Firstname = "Jytte",
                Lastname = "Larsen",
                City = "Esbjerg",
                Zipcode = 6700,
                Street = "EsbjergGade",
                StreetNumber = 3,
                Email = "jytte@esbjerg.dk",
                Orders = new List<Order> { o5 }
            };

            //SEED DB
            db.Customers.Add(c1);
            db.Customers.Add(c2);
            db.Customers.Add(c3);
            db.Customers.Add(c4);
            db.Events.Add(e1);
            db.Events.Add(e2);
            db.Events.Add(e3);
            db.Events.Add(e4);
            db.Events.Add(e5);
            db.Events.Add(e6);
            db.Events.Add(e7);
            db.Events.Add(e8);
            db.Events.Add(e9);

            base.Seed(db);
        }
    }
}
