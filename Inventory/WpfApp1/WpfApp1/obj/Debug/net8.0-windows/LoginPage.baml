   M S B A M L   `   `   `  ����B  >WpfApp1, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:WpfApp1WpfApp1  5          WpfApp1.LoginPage   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      'localclr-namespace:WpfApp1     5        N� Title$  	LoginPage��5	       N� 
Background
 �����.��5      �  � RowDefinitions 5   
   �� 5      $
��0.2* �6   �� 5      $
��0.3* �6   �� 5      $
��0.3* �6   �� 5      $
��0.3* �6   .+�5   
   �� $��LOGIN��6   $��Center=�6    $��Center=�6=   $��32(�6X   �� 5   
   $��1��6   $��Center=�6"   $��Center=�6=   .+�5      �� $��	Username:��6   $	��100��6(   $��Center=�67   �� 5      -   5         ��Name$ UsernameLabel��5      $�� ��6-   $	��100��65   5      �� 5   
   $��2��6   $��Center=�6"   $��Center=�6=   .+�5      �� $��	Password:��6   $	��100��6(   $��Center=�67   �� 5      -   5        $ PasswordLabel��5      $�� ��6-   $	��100��65   5      �� 5   
   -   5         ��Name$ LoginButton��5      $��Login��6&   $��3��66   6C   5       5!      