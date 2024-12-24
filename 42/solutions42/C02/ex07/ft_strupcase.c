int ft_strlen(char *str)
{
    int length = 0;
    while (str[length] != '\0')
        length++;
    return length;
}

char *ft_strupcase(char *str)
{
    int strLength = ft_strlen(str);
    for (int i = 0; i < strLength; i++)
        if (str[i] >= 'a' && str[i] <= 'z')
            str[i] -= 32;
    return str;
}
