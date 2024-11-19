int ft_strlen(char *str)
{
    int length = 0;
    while (str[length] != '\0')
        length++;
    return length;
}

char *ft_strlowcase(char *str)
{
    int strLength = ft_strlen(str);
    for (int i = 0; i < strLength; i++)
        if (str[i] >= 'A' && str[i] <= 'Z')
            str[i] += 32;
    return str;
}
