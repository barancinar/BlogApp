using BlogApp.Entity;
using Microsoft.EntityFrameworkCore;

namespace BlogApp.Data.Concrete.EfCore
{
    public static class SeedData
    {
        public static void TestVerileriniDoldur(IApplicationBuilder app)
        {
            var context = app.ApplicationServices.CreateScope().ServiceProvider.GetService<BlogContext>();

            if (context != null)
            {
                if (context.Database.GetPendingMigrations().Any())
                {
                    context.Database.Migrate();
                }
                if (!context.Tags.Any())
                {
                    context.Tags.AddRange(
                        new Tag { Text = "web programlama", Url = "web-programlama", Color = TagColors.warning },
                        new Tag { Text = "backend", Url = "backend", Color = TagColors.danger },
                        new Tag { Text = "frontend", Url = "frontend", Color = TagColors.success },
                        new Tag { Text = "fullstack", Url = "fullstack", Color = TagColors.primary },
                        new Tag { Text = "php", Url = "php", Color = TagColors.secondary }
                    );
                    context.SaveChanges();
                }
                if (!context.Users.Any())
                {
                    context.Users.AddRange(
                        new User
                        {
                            UserName = "barancinar",
                            Name = "Baran Çınar",
                            Email = "info@barancinar.com",
                            Password = "123456",
                            Image = "p1.jpg"
                        },
                        new User
                        {
                            UserName = "aliyanik",
                            Name = "Ali Yanik",
                            Email = "info@aliyanik.com",
                            Password = "123456",
                            Image = "p2.jpg"
                        }

                    );
                    context.SaveChanges();
                }
                if (!context.Posts.Any())
                {
                    context.Posts.AddRange(
                        new Post
                        {
                            Title = "Asp.Net Course",
                            Description = "Asp.net core dersleri",
                            Content = "Asp.net core dersleri",
                            Url = "aspnet-core",
                            IsActive = true,
                            Image = "1.jpg",
                            PublishedOn = DateTime.Now.AddDays(-10),
                            Tags = context.Tags.Take(4).ToList(),
                            UserId = 1,
                            Comments = new List<Comment> {
                                 new Comment { Text = "İyi bir kurs", PublishedOn = DateTime.Now.AddDays(-10), UserId = 1 },
                                 new Comment { Text = "çok faydalandığım bir kurs oldu.", PublishedOn = DateTime.Now.AddDays(-20), UserId = 2 }
                                 }
                        },
                        new Post
                        {
                            Title = "Php Course",
                            Description = "Php dersleri",
                            Content = "Php dersleri",
                            Url = "php-ders",
                            IsActive = true,
                            Image = "2.jpg",
                            PublishedOn = DateTime.Now.AddDays(-20),
                            Tags = context.Tags.Take(3).ToList(),
                            UserId = 2
                        },
                        new Post
                        {
                            Title = "Mobile App Course",
                            Description = "Mobile App dersleri",
                            Content = "Mobile App dersleri",
                            Url = "mobile-app",
                            IsActive = true,
                            Image = "3.jpg",
                            PublishedOn = DateTime.Now.AddDays(-15),
                            Tags = context.Tags.Take(2).ToList(),
                            UserId = 1
                        },
                        new Post
                        {
                            Title = "Angular Hakkında",
                            Description = "Angular dersleri",
                            Content = "Angular dersleri",
                            Url = "angular",
                            IsActive = true,
                            Image = "4.jpg",
                            PublishedOn = DateTime.Now.AddDays(-25),
                            Tags = context.Tags.Take(4).ToList(),
                            UserId = 1
                        },
                        new Post
                        {
                            Title = "React ile Uygulamalar",
                            Description = "React dersleri",
                            Content = "React dersleri",
                            Url = "react-app",
                            IsActive = true,
                            Image = "2.jpg",
                            PublishedOn = DateTime.Now.AddDays(-15),
                            Tags = context.Tags.Take(3).ToList(),
                            UserId = 1
                        },
                        new Post
                        {
                            Title = "Django Course",
                            Description = "Python Django dersleri",
                            Content = "Python Django dersleri",
                            Url = "django",
                            IsActive = true,
                            Image = "1.jpg",
                            PublishedOn = DateTime.Now.AddDays(-45),
                            Tags = context.Tags.Take(2).ToList(),
                            UserId = 1
                        },
                        new Post
                        {
                            Title = "Web Tasarım Course",
                            Description = "Web Tasarım dersleri",
                            Content = "Web Tasarım dersleri",
                            Url = "web-desing",
                            IsActive = true,
                            Image = "5.jpg",
                            PublishedOn = DateTime.Now.AddDays(-60),
                            Tags = context.Tags.Take(4).ToList(),
                            UserId = 1
                        }
                    );
                    context.SaveChanges();
                }
            }
        }
    }
}