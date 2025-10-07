public static class SimpleCalculator
{
    public static string Calculate(int operand1, int operand2, string? operation)
    {
        try
        {
            if (operand2 == 0 && operation == "/")
                return "Division by zero is not allowed.";
            
            ArgumentNullException.ThrowIfNull(operation);
            
            var calculationString = $"{operand1} {operation} {operand2} = ";
            
            var result = 0;
            
            switch (operation)
            {
                case "":
                    throw new ArgumentException();
                case "+":
                    result = SimpleOperation.Addition(operand1, operand2);
                    break;
                case "*":
                    result = SimpleOperation.Multiplication(operand1, operand2);
                    break;
                case "/":
                    result = SimpleOperation.Division(operand1, operand2);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
            return $"{calculationString}{result}";
        }
        catch (ArgumentNullException e)
        {
            Console.WriteLine(e);
            throw;
        }
        catch (ArgumentOutOfRangeException e)
        {
            Console.WriteLine(e);
            throw;
        }
        catch (ArgumentException e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}
