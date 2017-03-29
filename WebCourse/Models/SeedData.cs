using System;
using System.Linq;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace WebCourse.Models
{
    public static class SeedData {
    
        public static void AddValues(IApplicationBuilder builder) {
            ApplicationDbContext context = builder.ApplicationServices.GetRequiredService<ApplicationDbContext>();

            if(context.News.Count() == 0) {
                context.News.AddRange(
                    new News {
                        Content = @"<p>Lorem ipsum dolor sit amet, consectetur adipiscing elit. Integer nec odio. Praesent libero. Sed cursus ante dapibus diam. Sed nisi. Nulla quis sem at nibh elementum imperdiet. Duis sagittis ipsum. Praesent mauris. Fusce nec tellus sed augue semper porta. Mauris massa. Vestibulum lacinia arcu eget nulla. </p>

                                <p><b>Lorem ipsum dolor sit amet, consectetur adipiscing elit</b>. Class aptent taciti sociosqu ad litora torquent per conubia nostra, per inceptos himenaeos. <b>Lorem ipsum dolor sit amet, consectetur adipiscing elit</b>. Curabitur sodales ligula in libero. Sed dignissim lacinia nunc. <b>Praesent mauris</b>. Curabitur tortor. Pellentesque nibh. Aenean quam. In scelerisque sem at dolor. Maecenas mattis. <i>Lorem ipsum dolor sit amet, consectetur adipiscing elit</i>. Sed convallis tristique sem. Proin ut ligula vel nunc egestas porttitor. Morbi lectus risus, iaculis vel, suscipit quis, luctus non, massa. Fusce ac turpis quis ligula lacinia aliquet. </p>

                                <p><i>Lorem ipsum dolor sit amet, consectetur adipiscing elit</i>. Mauris ipsum. Nulla metus metus, ullamcorper vel, tincidunt sed, euismod in, nibh. Quisque volutpat condimentum velit. Class aptent taciti sociosqu ad litora torquent per conubia nostra, per inceptos himenaeos. Nam nec ante. Sed lacinia, urna non tincidunt mattis, tortor neque adipiscing diam, a cursus ipsum ante quis turpis. Nulla facilisi. Ut fringilla. Suspendisse potenti. Nunc feugiat mi a tellus consequat imperdiet. Vestibulum sapien. <i>In scelerisque sem at dolor</i>. Proin quam. </p>

                                <p>Etiam ultrices. Suspendisse in justo eu magna luctus suscipit. Sed lectus. Integer euismod lacus luctus magna. Quisque cursus, metus vitae pharetra auctor, sem massa mattis sem, at interdum magna augue eget diam. <b>Nunc feugiat mi a tellus consequat imperdiet</b>. Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia Curae; Morbi lacinia molestie dui. Praesent blandit dolor. <i>Sed lacinia, urna non tincidunt mattis, tortor neque adipiscing diam, a cursus ipsum ante quis turpis</i>. Sed non quam. In vel mi sit amet augue congue elementum. Morbi in ipsum sit amet pede facilisis laoreet. Donec lacus nunc, viverra nec, blandit vel, egestas et, augue. Vestibulum tincidunt malesuada tellus. Ut ultrices ultrices enim. </p>

                                <p>Curabitur sit amet mauris. Morbi in dui quis est pulvinar ullamcorper. Nulla facilisi. Integer lacinia sollicitudin massa. Cras metus. Sed aliquet risus a tortor. <i>Suspendisse in justo eu magna luctus suscipit</i>. Integer id quam. <b>Morbi in ipsum sit amet pede facilisis laoreet</b>. Morbi mi. Quisque nisl felis, venenatis tristique, dignissim in, ultrices sit amet, augue. Proin sodales libero eget ante. Nulla quam. </p>

                                ",
                        PublicationDateTime = DateTime.UtcNow.AddHours(3),
                        Title = "Новость 1",
                        Preview = "QWE"
                    },
                new News {
                    Content = @"<p>Lorem ipsum dolor sit amet, consectetur adipiscing elit. Integer nec odio. Praesent libero. Sed cursus ante dapibus diam. Sed nisi. Nulla quis sem at nibh elementum imperdiet. Duis sagittis ipsum. Praesent mauris. Fusce nec tellus sed augue semper porta. Mauris massa. Vestibulum lacinia arcu eget nulla. </p>

                                <p><b>Lorem ipsum dolor sit amet, consectetur adipiscing elit</b>. Class aptent taciti sociosqu ad litora torquent per conubia nostra, per inceptos himenaeos. <b>Lorem ipsum dolor sit amet, consectetur adipiscing elit</b>. Curabitur sodales ligula in libero. Sed dignissim lacinia nunc. <b>Praesent mauris</b>. Curabitur tortor. Pellentesque nibh. Aenean quam. In scelerisque sem at dolor. Maecenas mattis. <i>Lorem ipsum dolor sit amet, consectetur adipiscing elit</i>. Sed convallis tristique sem. Proin ut ligula vel nunc egestas porttitor. Morbi lectus risus, iaculis vel, suscipit quis, luctus non, massa. Fusce ac turpis quis ligula lacinia aliquet. </p>

                                <p><i>Lorem ipsum dolor sit amet, consectetur adipiscing elit</i>. Mauris ipsum. Nulla metus metus, ullamcorper vel, tincidunt sed, euismod in, nibh. Quisque volutpat condimentum velit. Class aptent taciti sociosqu ad litora torquent per conubia nostra, per inceptos himenaeos. Nam nec ante. Sed lacinia, urna non tincidunt mattis, tortor neque adipiscing diam, a cursus ipsum ante quis turpis. Nulla facilisi. Ut fringilla. Suspendisse potenti. Nunc feugiat mi a tellus consequat imperdiet. Vestibulum sapien. <i>In scelerisque sem at dolor</i>. Proin quam. </p>

                                <p>Etiam ultrices. Suspendisse in justo eu magna luctus suscipit. Sed lectus. Integer euismod lacus luctus magna. Quisque cursus, metus vitae pharetra auctor, sem massa mattis sem, at interdum magna augue eget diam. <b>Nunc feugiat mi a tellus consequat imperdiet</b>. Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia Curae; Morbi lacinia molestie dui. Praesent blandit dolor. <i>Sed lacinia, urna non tincidunt mattis, tortor neque adipiscing diam, a cursus ipsum ante quis turpis</i>. Sed non quam. In vel mi sit amet augue congue elementum. Morbi in ipsum sit amet pede facilisis laoreet. Donec lacus nunc, viverra nec, blandit vel, egestas et, augue. Vestibulum tincidunt malesuada tellus. Ut ultrices ultrices enim. </p>

                                <p>Curabitur sit amet mauris. Morbi in dui quis est pulvinar ullamcorper. Nulla facilisi. Integer lacinia sollicitudin massa. Cras metus. Sed aliquet risus a tortor. <i>Suspendisse in justo eu magna luctus suscipit</i>. Integer id quam. <b>Morbi in ipsum sit amet pede facilisis laoreet</b>. Morbi mi. Quisque nisl felis, venenatis tristique, dignissim in, ultrices sit amet, augue. Proin sodales libero eget ante. Nulla quam. </p>

                                ",
                    PublicationDateTime = DateTime.UtcNow.AddHours(3),
                    Title = "Новость 2",
                    Preview = "QWE"
                },
                new News {
                    Content = @"<p>Lorem ipsum dolor sit amet, consectetur adipiscing elit. Integer nec odio. Praesent libero. Sed cursus ante dapibus diam. Sed nisi. Nulla quis sem at nibh elementum imperdiet. Duis sagittis ipsum. Praesent mauris. Fusce nec tellus sed augue semper porta. Mauris massa. Vestibulum lacinia arcu eget nulla. </p>

                                <p><b>Lorem ipsum dolor sit amet, consectetur adipiscing elit</b>. Class aptent taciti sociosqu ad litora torquent per conubia nostra, per inceptos himenaeos. <b>Lorem ipsum dolor sit amet, consectetur adipiscing elit</b>. Curabitur sodales ligula in libero. Sed dignissim lacinia nunc. <b>Praesent mauris</b>. Curabitur tortor. Pellentesque nibh. Aenean quam. In scelerisque sem at dolor. Maecenas mattis. <i>Lorem ipsum dolor sit amet, consectetur adipiscing elit</i>. Sed convallis tristique sem. Proin ut ligula vel nunc egestas porttitor. Morbi lectus risus, iaculis vel, suscipit quis, luctus non, massa. Fusce ac turpis quis ligula lacinia aliquet. </p>

                                <p><i>Lorem ipsum dolor sit amet, consectetur adipiscing elit</i>. Mauris ipsum. Nulla metus metus, ullamcorper vel, tincidunt sed, euismod in, nibh. Quisque volutpat condimentum velit. Class aptent taciti sociosqu ad litora torquent per conubia nostra, per inceptos himenaeos. Nam nec ante. Sed lacinia, urna non tincidunt mattis, tortor neque adipiscing diam, a cursus ipsum ante quis turpis. Nulla facilisi. Ut fringilla. Suspendisse potenti. Nunc feugiat mi a tellus consequat imperdiet. Vestibulum sapien. <i>In scelerisque sem at dolor</i>. Proin quam. </p>

                                <p>Etiam ultrices. Suspendisse in justo eu magna luctus suscipit. Sed lectus. Integer euismod lacus luctus magna. Quisque cursus, metus vitae pharetra auctor, sem massa mattis sem, at interdum magna augue eget diam. <b>Nunc feugiat mi a tellus consequat imperdiet</b>. Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia Curae; Morbi lacinia molestie dui. Praesent blandit dolor. <i>Sed lacinia, urna non tincidunt mattis, tortor neque adipiscing diam, a cursus ipsum ante quis turpis</i>. Sed non quam. In vel mi sit amet augue congue elementum. Morbi in ipsum sit amet pede facilisis laoreet. Donec lacus nunc, viverra nec, blandit vel, egestas et, augue. Vestibulum tincidunt malesuada tellus. Ut ultrices ultrices enim. </p>

                                <p>Curabitur sit amet mauris. Morbi in dui quis est pulvinar ullamcorper. Nulla facilisi. Integer lacinia sollicitudin massa. Cras metus. Sed aliquet risus a tortor. <i>Suspendisse in justo eu magna luctus suscipit</i>. Integer id quam. <b>Morbi in ipsum sit amet pede facilisis laoreet</b>. Morbi mi. Quisque nisl felis, venenatis tristique, dignissim in, ultrices sit amet, augue. Proin sodales libero eget ante. Nulla quam. </p>

                                ",
                    PublicationDateTime = DateTime.UtcNow.AddHours(3),
                    Title = "Новость 3",
                    Preview = "QWE"
                },
                new News {
                    Content = @"<p>Lorem ipsum dolor sit amet, consectetur adipiscing elit. Integer nec odio. Praesent libero. Sed cursus ante dapibus diam. Sed nisi. Nulla quis sem at nibh elementum imperdiet. Duis sagittis ipsum. Praesent mauris. Fusce nec tellus sed augue semper porta. Mauris massa. Vestibulum lacinia arcu eget nulla. </p>

                                <p><b>Lorem ipsum dolor sit amet, consectetur adipiscing elit</b>. Class aptent taciti sociosqu ad litora torquent per conubia nostra, per inceptos himenaeos. <b>Lorem ipsum dolor sit amet, consectetur adipiscing elit</b>. Curabitur sodales ligula in libero. Sed dignissim lacinia nunc. <b>Praesent mauris</b>. Curabitur tortor. Pellentesque nibh. Aenean quam. In scelerisque sem at dolor. Maecenas mattis. <i>Lorem ipsum dolor sit amet, consectetur adipiscing elit</i>. Sed convallis tristique sem. Proin ut ligula vel nunc egestas porttitor. Morbi lectus risus, iaculis vel, suscipit quis, luctus non, massa. Fusce ac turpis quis ligula lacinia aliquet. </p>

                                <p><i>Lorem ipsum dolor sit amet, consectetur adipiscing elit</i>. Mauris ipsum. Nulla metus metus, ullamcorper vel, tincidunt sed, euismod in, nibh. Quisque volutpat condimentum velit. Class aptent taciti sociosqu ad litora torquent per conubia nostra, per inceptos himenaeos. Nam nec ante. Sed lacinia, urna non tincidunt mattis, tortor neque adipiscing diam, a cursus ipsum ante quis turpis. Nulla facilisi. Ut fringilla. Suspendisse potenti. Nunc feugiat mi a tellus consequat imperdiet. Vestibulum sapien. <i>In scelerisque sem at dolor</i>. Proin quam. </p>

                                <p>Etiam ultrices. Suspendisse in justo eu magna luctus suscipit. Sed lectus. Integer euismod lacus luctus magna. Quisque cursus, metus vitae pharetra auctor, sem massa mattis sem, at interdum magna augue eget diam. <b>Nunc feugiat mi a tellus consequat imperdiet</b>. Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia Curae; Morbi lacinia molestie dui. Praesent blandit dolor. <i>Sed lacinia, urna non tincidunt mattis, tortor neque adipiscing diam, a cursus ipsum ante quis turpis</i>. Sed non quam. In vel mi sit amet augue congue elementum. Morbi in ipsum sit amet pede facilisis laoreet. Donec lacus nunc, viverra nec, blandit vel, egestas et, augue. Vestibulum tincidunt malesuada tellus. Ut ultrices ultrices enim. </p>

                                <p>Curabitur sit amet mauris. Morbi in dui quis est pulvinar ullamcorper. Nulla facilisi. Integer lacinia sollicitudin massa. Cras metus. Sed aliquet risus a tortor. <i>Suspendisse in justo eu magna luctus suscipit</i>. Integer id quam. <b>Morbi in ipsum sit amet pede facilisis laoreet</b>. Morbi mi. Quisque nisl felis, venenatis tristique, dignissim in, ultrices sit amet, augue. Proin sodales libero eget ante. Nulla quam. </p>

                                ",
                    PublicationDateTime = DateTime.UtcNow.AddHours(3),
                    Title = "Новость 4",
                    Preview = "QWE"
                },
                new News {
                    Content = @"<p>Lorem ipsum dolor sit amet, consectetur adipiscing elit. Integer nec odio. Praesent libero. Sed cursus ante dapibus diam. Sed nisi. Nulla quis sem at nibh elementum imperdiet. Duis sagittis ipsum. Praesent mauris. Fusce nec tellus sed augue semper porta. Mauris massa. Vestibulum lacinia arcu eget nulla. </p>

                                <p><b>Lorem ipsum dolor sit amet, consectetur adipiscing elit</b>. Class aptent taciti sociosqu ad litora torquent per conubia nostra, per inceptos himenaeos. <b>Lorem ipsum dolor sit amet, consectetur adipiscing elit</b>. Curabitur sodales ligula in libero. Sed dignissim lacinia nunc. <b>Praesent mauris</b>. Curabitur tortor. Pellentesque nibh. Aenean quam. In scelerisque sem at dolor. Maecenas mattis. <i>Lorem ipsum dolor sit amet, consectetur adipiscing elit</i>. Sed convallis tristique sem. Proin ut ligula vel nunc egestas porttitor. Morbi lectus risus, iaculis vel, suscipit quis, luctus non, massa. Fusce ac turpis quis ligula lacinia aliquet. </p>

                                <p><i>Lorem ipsum dolor sit amet, consectetur adipiscing elit</i>. Mauris ipsum. Nulla metus metus, ullamcorper vel, tincidunt sed, euismod in, nibh. Quisque volutpat condimentum velit. Class aptent taciti sociosqu ad litora torquent per conubia nostra, per inceptos himenaeos. Nam nec ante. Sed lacinia, urna non tincidunt mattis, tortor neque adipiscing diam, a cursus ipsum ante quis turpis. Nulla facilisi. Ut fringilla. Suspendisse potenti. Nunc feugiat mi a tellus consequat imperdiet. Vestibulum sapien. <i>In scelerisque sem at dolor</i>. Proin quam. </p>

                                <p>Etiam ultrices. Suspendisse in justo eu magna luctus suscipit. Sed lectus. Integer euismod lacus luctus magna. Quisque cursus, metus vitae pharetra auctor, sem massa mattis sem, at interdum magna augue eget diam. <b>Nunc feugiat mi a tellus consequat imperdiet</b>. Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia Curae; Morbi lacinia molestie dui. Praesent blandit dolor. <i>Sed lacinia, urna non tincidunt mattis, tortor neque adipiscing diam, a cursus ipsum ante quis turpis</i>. Sed non quam. In vel mi sit amet augue congue elementum. Morbi in ipsum sit amet pede facilisis laoreet. Donec lacus nunc, viverra nec, blandit vel, egestas et, augue. Vestibulum tincidunt malesuada tellus. Ut ultrices ultrices enim. </p>

                                <p>Curabitur sit amet mauris. Morbi in dui quis est pulvinar ullamcorper. Nulla facilisi. Integer lacinia sollicitudin massa. Cras metus. Sed aliquet risus a tortor. <i>Suspendisse in justo eu magna luctus suscipit</i>. Integer id quam. <b>Morbi in ipsum sit amet pede facilisis laoreet</b>. Morbi mi. Quisque nisl felis, venenatis tristique, dignissim in, ultrices sit amet, augue. Proin sodales libero eget ante. Nulla quam. </p>

                                ",
                    PublicationDateTime = DateTime.UtcNow.AddHours(3),
                    Title = "Новость 5",
                    Preview = "QWE"
                },
                new News {
                    Content = @"<p>Lorem ipsum dolor sit amet, consectetur adipiscing elit. Integer nec odio. Praesent libero. Sed cursus ante dapibus diam. Sed nisi. Nulla quis sem at nibh elementum imperdiet. Duis sagittis ipsum. Praesent mauris. Fusce nec tellus sed augue semper porta. Mauris massa. Vestibulum lacinia arcu eget nulla. </p>

                                <p><b>Lorem ipsum dolor sit amet, consectetur adipiscing elit</b>. Class aptent taciti sociosqu ad litora torquent per conubia nostra, per inceptos himenaeos. <b>Lorem ipsum dolor sit amet, consectetur adipiscing elit</b>. Curabitur sodales ligula in libero. Sed dignissim lacinia nunc. <b>Praesent mauris</b>. Curabitur tortor. Pellentesque nibh. Aenean quam. In scelerisque sem at dolor. Maecenas mattis. <i>Lorem ipsum dolor sit amet, consectetur adipiscing elit</i>. Sed convallis tristique sem. Proin ut ligula vel nunc egestas porttitor. Morbi lectus risus, iaculis vel, suscipit quis, luctus non, massa. Fusce ac turpis quis ligula lacinia aliquet. </p>

                                <p><i>Lorem ipsum dolor sit amet, consectetur adipiscing elit</i>. Mauris ipsum. Nulla metus metus, ullamcorper vel, tincidunt sed, euismod in, nibh. Quisque volutpat condimentum velit. Class aptent taciti sociosqu ad litora torquent per conubia nostra, per inceptos himenaeos. Nam nec ante. Sed lacinia, urna non tincidunt mattis, tortor neque adipiscing diam, a cursus ipsum ante quis turpis. Nulla facilisi. Ut fringilla. Suspendisse potenti. Nunc feugiat mi a tellus consequat imperdiet. Vestibulum sapien. <i>In scelerisque sem at dolor</i>. Proin quam. </p>

                                <p>Etiam ultrices. Suspendisse in justo eu magna luctus suscipit. Sed lectus. Integer euismod lacus luctus magna. Quisque cursus, metus vitae pharetra auctor, sem massa mattis sem, at interdum magna augue eget diam. <b>Nunc feugiat mi a tellus consequat imperdiet</b>. Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia Curae; Morbi lacinia molestie dui. Praesent blandit dolor. <i>Sed lacinia, urna non tincidunt mattis, tortor neque adipiscing diam, a cursus ipsum ante quis turpis</i>. Sed non quam. In vel mi sit amet augue congue elementum. Morbi in ipsum sit amet pede facilisis laoreet. Donec lacus nunc, viverra nec, blandit vel, egestas et, augue. Vestibulum tincidunt malesuada tellus. Ut ultrices ultrices enim. </p>

                                <p>Curabitur sit amet mauris. Morbi in dui quis est pulvinar ullamcorper. Nulla facilisi. Integer lacinia sollicitudin massa. Cras metus. Sed aliquet risus a tortor. <i>Suspendisse in justo eu magna luctus suscipit</i>. Integer id quam. <b>Morbi in ipsum sit amet pede facilisis laoreet</b>. Morbi mi. Quisque nisl felis, venenatis tristique, dignissim in, ultrices sit amet, augue. Proin sodales libero eget ante. Nulla quam. </p>

                                ",
                    PublicationDateTime = DateTime.UtcNow.AddHours(3),
                    Title = "Новость 6",
                    Preview = "QWE"
                });
                context.SaveChanges();
            }
        }
    }
}
