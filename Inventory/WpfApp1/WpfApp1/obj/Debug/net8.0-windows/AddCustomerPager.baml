   M S B A M L   `   `   `  ����B  >WpfApp1, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:WpfApp1WpfApp1  5          WpfApp1.AddCustomerPager   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      'localclr-namespace:WpfApp1     5        N� Title$  AddCustomerPager��5	       N� 
Background
 �����.��5      �  � RowDefinitions 5   
   �� 5      $
��0.2* �6   �� 5      $
��0.3* �6   �� 5      $
��0.3* �6   �� 5      $
��0.3* �6   �� 5      $
��0.3* �6    � ColumnDefinitions 5   
   �� 5      $
��0.1* �6   �� 5      $��* �6   .+�5   
   �� -   5        $
��Back��5      $��32(�6    $��2��6.   $
��Left=�6B   $��73��6]   6h   �� 5   
   $��Add Customer��6   $��32(�6'   $��2��65   $��0��6I   $��Center=�6Y   $��Center=�6t   �� 5   
   $��2��6   $��1��6)   $��0��66   $��Center=�6F   $��Center=�6a   .+�5      �� $��Enter your username:��6   �� 5      -   5         ��Name$ AddCustomerUsernameTB��5      $��30��65   $	��200��6A   5      �� 5!   
   $��2��6   $��2��6)   $��0��66   $��Center=�6F   $��Center=�6a   .+�5"      �� $��Enter your Email:��6   �� 5#      -   5        $ AddCustomerEmailTB��5#      $��30��62   $	��200��6>   5$      �� 5&   
   $��2��6   $��3��6)   $��0��66   $��Center=�6F   $��Center=�6a   .+�5'      �� $��Enter your Password:��6   �� 5(      -   5        $ AddCustomerPasswordTB��5(      $��30��65   $	��200��6A   5)      �� 5+   
   -   5         ��Name$ RegisterCustomerBtn��5+      $��300, 20, 300, 20q�6.   $��2��6H   $��0��6\   $��4��6l   $��Register��6y   $��32(�6�   6�   5-      5.      