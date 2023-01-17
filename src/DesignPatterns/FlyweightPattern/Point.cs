using System;
using System.Collections;
using System.Collections.Generic;

namespace FlyweightPattern
{
    /*
    public class Point
    {
        private int x; // 4 bytes
        private int y; // 4 bytes
        private PointType type; // 4 bytes
        private byte[] icon;  // 10 kb

        public Point(int x, int y, PointType type, byte[] icon)
        {
            this.x = x;
            this.y = y;
            this.type = type;
            this.icon = icon;
        }

        public void Draw() => Console.WriteLine($"{type} at ({x},{y})");
    }
    */
    
    
    
    public class Point
    {
        public int X { get; } // 4 bytes
        public int Y { get; } // 4 bytes
        public PointIcon Icon { get; }

        public Point(int x, int y, PointIcon icon)
        {
            this.X = x;
            this.Y = y;
            this.Icon = icon;
        }
        
        public void Draw() => Console.WriteLine($"{Icon.Type} at ({X},{Y})");
    }

    // Flyweight
    public class PointIcon
    {
        public PointType Type { get; } // 4 bytes
        public byte[] Icon { get; }  // 10 kb

        public PointIcon(PointType type, byte[] icon)
        {
            this.Type = type;
            this.Icon = icon;
        }
    }

    
    public enum PointType
    {
        Cafe,
        Hotel
    }
    
    // Flyweight Factory
    public class PointIconFactory
    {
        private readonly Dictionary<PointType, PointIcon> icons = new();
        
        public PointIcon Get(PointType type)
        {
            if (!icons.ContainsKey(type))
            {
                var icon = new PointIcon(type, null);
                // cafe.jpg
                // hotel.jpg
                
                icons.Add(type, icon);
            }

            return icons[type];
        }
    }

    public class PointService
    {
        private readonly IEnumerable<Point> points;

        public PointService(PointIconFactory pointIconFactory)
        {
            // points = new List<Point>
            // {
            //     new Point(10, 20, new PointIcon(PointType.Cafe, null)), 
            //     new Point(20, 40, new PointIcon(PointType.Cafe, null)),
            // };

            points = new List<Point>
            {
                new Point(10, 20, pointIconFactory.Get(PointType.Cafe)),
                new Point(20, 40, pointIconFactory.Get(PointType.Cafe)),
            };
        }

        public IEnumerable<Point> Get()
        {
            return points;
        }
    }

}