int ft_atoi(char *str)
{
    int i = 0;
    int sign = 1;
    int final = 0;
    while (str[i] == ' ')
        i++;
    while (str[i] == '+' || str[i] == '-')
    {
        if (str[i] == '-')
            sign *= -1;
        i++;
    }
    while (str[i] >= '0' && str[i] <= '9')
    {
        final *= 10;
        final += (str[i] - '0');
        i++;
    }
    return final * sign;
}
