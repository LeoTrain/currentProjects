   M S B A M L   `   `   `  ����B  >WpfApp1, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:WpfApp1WpfApp1  5           WpfApp1.ManageCustomerPage   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      'localclr-namespace:WpfApp1     5        N� Title$  ManageCustomerPage��5	       N� 
Background
 �����.��5      �  � RowDefinitions 5   
   �� 5      $
��0.2* �6   �� 5      $��0.09* �6   �� 5      $��* �6   .+�5   
   ��  �� Orientation$ 
Horizontal=�6   .+�5      �� -   5        $
��BACK��5      $��32(�6$   62   �� 5      $��175, 0, 0, 0q�6   $��0��6*   $��Manage Customers��67   $��32(�6R   $��Center=�6`   $��Center=�5      5      �� 5   
   $ 
Horizontal=�6   $��1��6.   .+�5      �� -   5         ��Name$ ModifyUserBtn��5   +   $��Modify User��6   $��75��6C   6N   �� 5      -   5        $ UserOderstn��5   &   $��Orders��6   $��75��6;   5      &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ UsersDataGrid��5      $��2��6*      AutoGenerateColumns$ False��67   $��Stretch=�6S   $��Stretch=�5       $��10q�6/      Columns 5!      0  *System.Windows.Controls.DataGridTextColumn  5"      ,  &System.Windows.Controls.DataGridColumn   Width5  /System.Windows.Controls.DataGridLengthConverter$ * 6%   	   Header$	 ID��6/   1  +System.Windows.Controls.DataGridBoundColumn
   Binding
 6;   �� *
CustomerID+  5#      $ * 6%   $
	 Name��6/   
 6=   �� *Name+  5$      $ * 6%   $	 Email��6/   
 6>   �� *Email+  5%      $ * 6%   $	 PasswordHash��6/   
 6E   �� *PasswordHash+5'      5)      5*      