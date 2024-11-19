int ft_strlen(char *str)
{
    int length = 0;
    while (str[length] != '\0')
        length++;
    return length;
}

int ft_str_is_uppercase(char *str)
{
    if (str[0] == '\0')
        return 1;
    int strLength = ft_strlen(str);
    for (int i = 0; i < strLength; i++)
    {
        if (!(str[i] >= 'A' && str[i] <= 'Z'))
            return 0;
    }
    return 1;
}
