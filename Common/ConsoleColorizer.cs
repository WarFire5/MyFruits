namespace MyFruits.Common
{
    public static class ConsoleColorizer
    {
        private static readonly bool UseHeaderBackground = true;

        private static readonly ConsoleColor HeaderBg = ConsoleColor.Gray;

        private static readonly ConsoleColor HeaderFgDefault = ConsoleColor.Cyan;

        public static void WriteBlockWithColoredColors(string block)
        {
            if (block is null)
            {
                Console.WriteLine("<null>");
                return;
            }

            var prevFg = Console.ForegroundColor;
            var prevBg = Console.BackgroundColor;

            var lines = block.Replace("\r\n", "\n").Split('\n');
            foreach (var raw in lines)
            {
                var line = raw ?? string.Empty;

                if (IsHeader(line, out var typeName))
                {
                    var fg = MapHeader(typeName);

                    var oldFg = Console.ForegroundColor;
                    var oldBg = Console.BackgroundColor;

                    if (UseHeaderBackground)
                        Console.BackgroundColor = HeaderBg;

                    Console.ForegroundColor = (fg == ConsoleColor.Black && Console.BackgroundColor == ConsoleColor.Black)
                        ? ConsoleColor.White
                        : fg;

                    Console.Write(line);
                    Console.ForegroundColor = oldFg;
                    Console.BackgroundColor = oldBg;
                    Console.WriteLine();
                    continue;
                }

                const string prefix = "  Цвет: ";
                if (line.StartsWith(prefix, StringComparison.Ordinal))
                {
                    var colorName = line.Substring(prefix.Length).Trim();
                    if (Enum.TryParse<ProduceColor>(colorName, ignoreCase: false, out var pc))
                    {
                        Console.Write(prefix);

                        var mapped = Map(pc);
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
            _ => HeaderFgDefault
        };

        private static bool IsHeader(string line, out string typeName)
        {
            typeName = string.Empty;
            if (string.IsNullOrEmpty(line)) return false;
            if (line[0] != '[' || !line.EndsWith("]") || line.Length <= 2) return false;
            typeName = line.Substring(1, line.Length - 2);
            return true;
        }
    }
}