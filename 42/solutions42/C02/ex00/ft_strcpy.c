int ft_strlen(char *str)
{
    int length = 0;
    while (str[length] != '\0')
        length++;
    return length;
}

char *ft_strcpy(char *dest, char *src)
{
    int srcLength = ft_strlen(src);
    for (int i = 0; i < srcLength; i++)
        dest[i] = src[i];
    dest[srcLength] = '\0';
    return dest;
}
