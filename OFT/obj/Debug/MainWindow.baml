   M S B A M L   `   `   `  ����>  :TCG, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:TCGTCG  5   	       TCG.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   #localclr-namespace:TCG     5   	     � Title$  
MainWindow��5   	   $	��450��6   $	��800��6)   .��5	      �  � ColumnDefinitions 5
   
   �� 5      $
��459* �6   �� 5      $
��334* �6   .+�5   
   �� -   5        $��input��5      $
��Left=�6   $	��135��6:   $��	10,10,0,0q�6G    �� TextWrapping$ WrapWithOverflow=�6Z   $	��Top=�6z   $	��622��6�    �� AcceptsReturn . " �� VerticalScrollBarVisibility$ Visible=�6�   $ �� HorizontalScrollBarVisibility$
 Auto=�6�   $��2��6�   .��6   � 	Resources 5         HintText j� TileMode �� Opacity	 j� Stretch
 j� 
AlignmentX !� Visual��%  &	        !� 5      $
 None=�6/   $	 0.5Q�6?   $
	 None=�6M   $

 Left=�6\    5      �� 5      $��Italic$�6$   $o��i[因素]:[水平1],[水平2]...[水平n] (回车换行,写下个因素,注意尽量用英文标点符号)��67   5      5      .��6!   ��5      �� 5       �� 
TargetType" ��6    �� Triggers 5      P� 5       P� Property � �� P� Value 62   Z� . �5      ��  �� Property � �� �� Value# [  6;   5      P� 5       � ��$  ��62   . �5      ��  � ��# [  6;   5      5       .��5!      5"      �� 5#   
   -   5         ��Name$ submit��5#      $��生成测试用例��6!   $
��Left=�62   $��177.8,10,0,0q�6M   $	��Top=�6c   $	��147��6{   $��42��6�   $��1��6�   �� 5$   
   -   5        $
 exit��5$      $��退出��6   $
��Left=�6,   $��177.8,103,0,0q�6G   $	��Top=�6^   $	��147��6v   $��42��6�   $��1��6�   �� 5%   
   -   5         ��Name$ result��5%      $
��Left=�6"   $	��250��6=   $��
10,160,0,0q�6J   $ WrapWithOverflow=�6^   $	��Top=�6~   $	��774��6�   $ Visible=�6�   $ Visible=�6�    �� 
IsReadOnly . $��2��6  5'      5(      