   M S B A M L   `   `   `  ����I  EInitialProject, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:InitialProject.ViewInitialProject.View  5   	   &     InitialProject.View.ReportWindow   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   3local!clr-namespace:InitialProject.View     5   	   -   5        
�������  � Title$  ReportWindow��5      $	��500��6    $	��530��6-    � 
ResizeMode$ NoResize=�69    � WindowStyle$
 None=�6O   $��Roboto)�6b    � WindowStartupLocation$ CenterScreen=�6v   .��5      �� .��5   
   � -   5         �Name$ printableContent��5   8   -  'System.Windows.Input.KeyboardNavigation   TabNavigation$ Cycle=�6   
�������.+�5      �� 
�������$��34,192,34,73q�6�   ��61   �� *Reservations+ �� SelectedItem 6V   �� *SelectedReservation+��5      �� 5       �� 
TargetType" ��6   .�5      ��  �� Property � ��	 �� Value
	 �����67   5      
 �� View
 5      �� 5      .P�5      �� $
��Name��6)    �� DisplayMemberBinding 67   �� *Name+�� 5      $��CheckInDate��6)    6>   �� *CheckInDate+�� 5      $��CheckOutDate��6)    6?   �� *CheckOutDate+�� 5      $��NumberOfGuests��6)    6A   �� *NumberOfGuests+6s   5       5"      �� 5#      $��P��6   $
��Bold"�6    $
��Left=�62   $��456,149,0,0q�6M   $	��Top=�6b   $��10(�6z    J� RenderTransformOrigin$ -0.805,0.549&�6�   $��29��6�   �� 5$      $��Center=�6   $��0,30,0,0q�65   $
��Wrap=�6G   $.��(Report for all reservated accomodations!��6[   $��20(�6�   $
��Bold"�6�   $	��Top=�6�   $	��396��6�   �� 5%      $��X��6   $
��Bold"�6    $
��Left=�62   $��
480,30,0,0q�6M   $	��Top=�6a   $��10(�6y   $ -0.805,0.549&�6�   �� 5&      $
��Exit��6   $
��Left=�6$   $��
473,10,0,0q�6?   $	��Top=�6S   $��21��6k   $��30��6w   �� 5'      $��Print��6   $
��Left=�6%   $��449,170,0,0q�6@   $	��Top=�6U   $��20��6m   $��30��6y   �� 5(      $��Center=�6   $��	0,161,0,0q�65   $
��Wrap=�6H   $��Reserved accomodations:��6\   $��14(�6{   $	��Top=�6�   $	��163��6�   5,      5.      5/      