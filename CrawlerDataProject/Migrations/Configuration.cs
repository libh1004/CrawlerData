namespace CrawlerDataProject.Migrations
{
    using CrawlerDataProject.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<CrawlerDataProject.Data.MyDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(CrawlerDataProject.Data.MyDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.

            IList<Article> articles = new List<Article>();
            articles.Add(new Article()
            {
                Title = "Vì sao uranium được dùng chế tạo bom nguyên tử?",
                Content = "Uranium là một trong những nguyên tố tự nhiên nặng nhất. Trong hạt nhân của nó, có 92 proton và một " +
                "lượng neutron thay đổi, từ 140 đến 146. Tuy nhiên, chỉ một số sự kết hợp xảy ra một cách tự phát, phong phú nhất" +
                "là uranium-238 (92 proton và 146 neutron) và uranium-235 (92 proton và 146 neutron).",
                Thumbnail = "https://i1-vnexpress.vnecdn.net/2022/03/14/uranium-6535-1647232930.jpg?w=680&h=0&q=100&dpr=1&fit=crop&s=iLnwhdoFDlAuOBxLx6K7AQ",
                Author = "Đoàn Dương"
            });

            articles.Add(new Article()
            {
                Title = "Vì sao uranium được dùng chế tạo bom nguyên tử? 1",
                Content = "Uranium là một trong những nguyên tố tự nhiên nặng nhất. Trong hạt nhân của nó, có 92 proton và một " +
               "lượng neutron thay đổi, từ 140 đến 146. Tuy nhiên, chỉ một số sự kết hợp xảy ra một cách tự phát, phong phú nhất" +
               "là uranium-238 (92 proton và 146 neutron) và uranium-235 (92 proton và 146 neutron).",
                Thumbnail = "https://i1-vnexpress.vnecdn.net/2022/03/14/uranium-6535-1647232930.jpg?w=680&h=0&q=100&dpr=1&fit=crop&s=iLnwhdoFDlAuOBxLx6K7AQ",
                Author = "Đoàn Dương"
            });
            articles.Add(new Article()
            {
                Title = "Vì sao uranium được dùng chế tạo bom nguyên tử? 2",
                Content = "Uranium là một trong những nguyên tố tự nhiên nặng nhất. Trong hạt nhân của nó, có 92 proton và một " +
               "lượng neutron thay đổi, từ 140 đến 146. Tuy nhiên, chỉ một số sự kết hợp xảy ra một cách tự phát, phong phú nhất" +
               "là uranium-238 (92 proton và 146 neutron) và uranium-235 (92 proton và 146 neutron).",
                Thumbnail = "https://i1-vnexpress.vnecdn.net/2022/03/14/uranium-6535-1647232930.jpg?w=680&h=0&q=100&dpr=1&fit=crop&s=iLnwhdoFDlAuOBxLx6K7AQ",
                Author = "Đoàn Dương"
            });
            articles.Add(new Article()
            {
                Title = "Vì sao uranium được dùng chế tạo bom nguyên tử? 3",
                Content = "Uranium là một trong những nguyên tố tự nhiên nặng nhất. Trong hạt nhân của nó, có 92 proton và một " +
               "lượng neutron thay đổi, từ 140 đến 146. Tuy nhiên, chỉ một số sự kết hợp xảy ra một cách tự phát, phong phú nhất" +
               "là uranium-238 (92 proton và 146 neutron) và uranium-235 (92 proton và 146 neutron).",
                Thumbnail = "https://i1-vnexpress.vnecdn.net/2022/03/14/uranium-6535-1647232930.jpg?w=680&h=0&q=100&dpr=1&fit=crop&s=iLnwhdoFDlAuOBxLx6K7AQ",
                Author = "Đoàn Dương"
            });
            articles.Add(new Article()
            {
                Title = "Vì sao uranium được dùng chế tạo bom nguyên tử? 4",
                Content = "Uranium là một trong những nguyên tố tự nhiên nặng nhất. Trong hạt nhân của nó, có 92 proton và một " +
               "lượng neutron thay đổi, từ 140 đến 146. Tuy nhiên, chỉ một số sự kết hợp xảy ra một cách tự phát, phong phú nhất" +
               "là uranium-238 (92 proton và 146 neutron) và uranium-235 (92 proton và 146 neutron).",
                Thumbnail = "https://i1-vnexpress.vnecdn.net/2022/03/14/uranium-6535-1647232930.jpg?w=680&h=0&q=100&dpr=1&fit=crop&s=iLnwhdoFDlAuOBxLx6K7AQ",
                Author = "Đoàn Dương"
            });

            foreach(Article article in articles)
            {
                context.Articles.Add(article);
                base.Seed(context);
            }
        }
    }
}
