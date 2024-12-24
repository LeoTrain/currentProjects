#include <stdlib.h>

char ft_strlen(char *src)
{
    int i = 0;
    while (src[i] != '\0')
        i++;
    return i;
}

char *ft_strdup(char *src)
{
    int src_length = ft_strlen(src);
    char *new_pointer = (char*)malloc((src_length + 1) * 1);

    if (!new_pointer)
        return NULL;

    for (int i = 0; i < src_length; i++)
    {
        new_pointer[i] = src[i];
    }

    new_pointer[src_length] = '\0';

    return new_pointer;
}
