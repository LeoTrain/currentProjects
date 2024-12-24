int ft_strlen(char *str)
{
    int length = 0;
    while (str[length] != '\0')
        length++;
    return length;
}

int ft_str_is_alpha(char *str)
{
    if (str[0] == '\0')
        return 1;
    int strLength = ft_strlen(str);
    for (int i = 0; i < strLength; i++)
    {
        if (!((str[i] >= 'A' && str[i] <= 'Z') || (str[i] >= 'a' && str[i] <= 'z')))
            return 0;
    }
    return 1;
}
