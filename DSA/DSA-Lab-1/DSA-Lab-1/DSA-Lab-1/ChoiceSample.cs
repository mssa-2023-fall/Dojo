namespace DSA_Lab_1
{
    public record class ChoiceSample
    {
        public string GetDishRecommendation(string proteinChoices)
        {
            switch (proteinChoices.ToLower())
            {
                case "beef":
                    return "Hamburger";
                case "pepperoni":
                    return "Pizza";
                case "tofu":
                    return "Tofu Fried Rice";
                default:
                    return "That choice is not available";
            }
        }
    }
}