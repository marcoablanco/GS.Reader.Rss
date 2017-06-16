namespace Krillin.App.UITests
{
    using System;
    using Xamarin.UITest;

    
    public class AppInitializer
    {
        /// <summary>
        /// Starts the application.
        /// </summary>
        /// <param name="platform">The platform.</param>
        /// <returns></returns>
        /// <exception cref="System.PlatformNotSupportedException"></exception>
        public static IApp StartApp(Platform platform)
        {
            if (platform == Platform.Android)
            {
                return ConfigureApp
                    .Android
                    .StartApp();
            }
            else if (platform == Platform.iOS)
            {
                return ConfigureApp
                    .iOS
                    .StartApp();
            }

            throw new PlatformNotSupportedException($"{platform} is not supported.");
        }
    }
}

