using Application.Contracts.Common;
using Application.Models;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class TopicMatcher
    {
        private const double EarthRadiusMeters = 6371000;

        public static List<Topic2> FindMatchingTopics(List<Topic2> topics, Location userLocation, double radiusMeters)
        {
            var matchingTopics = new List<Topic2>();
            foreach (var topic in topics)
            {
                var distance = HaversineDistance(userLocation.Latitude, userLocation.Longitude, topic.Location.Latitude, topic.Location.Longitude);
                if (distance <= radiusMeters)
                {
                    matchingTopics.Add(topic);
                }
            }
            return matchingTopics;
        }

        private static double HaversineDistance(double lat1, double lon1, double lat2, double lon2)
        {
            var dLat = Radians(lat2 - lat1);
            var dLon = Radians(lon2 - lon1);

            var a = Math.Sin(dLat / 2) * Math.Sin(dLat / 2) +
                    Math.Cos(Radians(lat1)) * Math.Cos(Radians(lat2)) *
                    Math.Sin(dLon / 2) * Math.Sin(dLon / 2);

            var c = 2 * Math.Asin(Math.Sqrt(a));
            return c * EarthRadiusMeters;
        }

        private static double Radians(double degrees)
        {
            return degrees * Math.PI / 180;
        }
    }
}
