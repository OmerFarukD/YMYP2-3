using System.ComponentModel.DataAnnotations;

namespace UserManagmentSystem.Attributes.Validations;

public class PasswordRuleAttribute : ValidationAttribute
{
    public int Min { get; set; }

    public PasswordRuleAttribute(int min=6)
    {
        Min = min;
    }

    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {

        if (value is string text)
        {
            bool result = PasswordRules(text);
            if (!result)
            {
                return new ValidationResult(getMessage());
            }
        }
        
        return ValidationResult.Success;
    }
    
    private bool PasswordRules(string text)
    {
        char[] specialCharacters = new char[] { '.', ',','!','?'};    
        if (text.Length >= Min)   
        {        int lowNum = 0, upNum = 0, specNum = 0, digitNum=0;
            foreach (char item in specialCharacters)
            {            if (text.Contains(item))
                specNum++;
                
            } foreach (char character in text) 
            {
                if (char.IsLower(character))
                    lowNum++;            
                if (char.IsUpper(character))
                    upNum++;

                if (char.IsDigit(character))
                {
                    digitNum++;
                }
                
            }

            if (lowNum == 0 || upNum == 0 || specNum == 0 || digitNum==0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        else
        {
            return false;
        }
    }

    private string getMessage()
    {
        return $"Parola minimum {Min} haneli olmalıdır." +
               "Parola içerisinde minimum 1 tane büyük karakter," +
               "1 Tane küçük, 1 tane özel karakter ve en az bir rakam içermelidir.";
    }
}