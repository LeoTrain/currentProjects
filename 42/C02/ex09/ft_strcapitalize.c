int ft_strlen(char *str)
{
    int length = 0;
    while (str[length] != '\0')
        length++;
    return length;
}

char *ft_strcapitalize(char *str)
{
    int strLength = ft_strlen(str);
    int isStart = 1;
    for (int i = 0; i < strLength; i++)
    {
        if (isStart == 1)
        {
            if (str[i] >= 'a' && str[i] <= 'z')
                str[i] -= 32;
            isStart = 0;
        }
        else 
        {
            if (str[i] >= 'A' && str[i] <= 'Z') str[i] += 32; 

            if (!((str[i] >= 'A' && str[i] <= 'Z') || (str[i] >= 'a' && str[i] <= 'z')))
                if (!(str[i] >= '0' && str[i] <= '9'))
                    if (str[i+1] >= 'a' && str[i+1] <= 'z')
                        isStart = 1;
        }

    }
    return str;
}
