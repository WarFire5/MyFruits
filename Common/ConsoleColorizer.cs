namespace MyFruits.Common
{
    public static class ConsoleColorizer
    {
        public static ConsoleColor Map(ProduceColor color) => color switch
        {
            ProduceColor.Красный => ConsoleColor.Red,
            ProduceColor.Оранжевый => ConsoleColor.DarkYellow,
            ProduceColor.Жёлтый => ConsoleColor.Yellow,
            ProduceColor.Зелёный => ConsoleColor.Green,
            ProduceColor.Синий => ConsoleColor.Blue,
            ProduceColor.Фиолетовый => ConsoleColor.Magenta,
            ProduceColor.Розовый => ConsoleColor.Magenta,
            ProduceColor.Коричневый => ConsoleColor.DarkYellow,
            ProduceColor.Чёрный => ConsoleColor.Black,
            ProduceColor.Белый => ConsoleColor.White,
            _ => ConsoleColor.Gray
        };

        private static ConsoleColor MapHeader(string typeName) => typeName switch
        {
            "Apple" => ConsoleColor.DarkRed,
            "Berry" => ConsoleColor.DarkMagenta,
            "Potato" => ConsoleColor.DarkYellow,
            "Tomato" => ConsoleColor.Red,
            "Fruit" => ConsoleColor.Cyan,
            "Vegetable" => ConsoleColor.Cyan,
            _ => ConsoleColor.Cyan
        };

        public static void WriteBlockWithColoredColors(string block)
        {
            var prevFg = Console.ForegroundColor;
            var prevBg = Console.BackgroundColor;

            var lines = block.Replace("\r\n", "\n").Split('\n');
            foreach (var raw in lines)
            {
                var line = raw ?? string.Empty;
                if (line.Length == 0) { Console.WriteLine(); continue; }

                if (line[0] == '[' && line.EndsWith("]") && line.Length > 2)
                {
                    var typeName = line.Substring(1, line.Length - 2);
                    var c = MapHeader(typeName);

                    var useBg = Console.BackgroundColor == ConsoleColor.Black;
                    if (useBg)
                    {
                        Console.BackgroundColor = ConsoleColor.Gray;
                        Console.ForegroundColor = c == ConsoleColor.Black ? ConsoleColor.White : c;
                        Console.WriteLine(line);
                        Console.BackgroundColor = prevBg;
                        Console.ForegroundColor = prevFg;
                    }
                    else
                    {
                        Console.ForegroundColor = c;
                        Console.WriteLine(line);
                        Console.ForegroundColor = prevFg;
                    }
                    continue;
                }

                const string prefix = "  Цвет: ";
                if (line.StartsWith(prefix, StringComparison.Ordinal))
                {
                    var colorName = line.Substring(prefix.Length).Trim();
                    if (Enum.TryParse<ProduceColor>(colorName, ignoreCase: false, out var color))
                    {
                        Console.Write(prefix);
                        var mapped = Map(color);

                        if (mapped == ConsoleColor.Black && Console.BackgroundColor == ConsoleColor.Black)
                            mapped = ConsoleColor.DarkGray;

                        Console.ForegroundColor = mapped;
                        Console.Write(colorName);
                        Console.ForegroundColor = prevFg;
                        Console.WriteLine();
                        continue;
                    }
                }

                Console.WriteLine(line);
            }

            Console.ForegroundColor = prevFg;
            Console.BackgroundColor = prevBg;
        }
    }
}