   M S B A M L   `   `   `  ����O  Kmscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e0891&clr-namespace:System;assembly=mscorlibSystem  5   	   J FMrMitch.Loaders, Version=1.2.0.0, Culture=neutral, PublicKeyToken=null:.clr-namespace:Loaders;assembly=MrMitch.LoadersLoaders 5   	   > :PPC, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:PPCPPC 5   	      PPC.UT_Form   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   9system&clr-namespace:System;assembly=mscorlib     5   	   Bloaders.clr-namespace:Loaders;assembly=MrMitch.Loaders     5   	   #localclr-namespace:PPC     5   	     � 
ResizeMode$  NoResize=�5
   	    � WindowStyle$
 None=�5   	    � Title$ UT_Form��5   	   $	��386��5   	   $	��430��6    � Topmost .  � WindowStartupLocation$ CenterScreen=�5   	      PPC#��[  5   	   .��5      �   
windowsPPC#��[ 6    � RowDefinitions 5   
   �� 5      $	��31* �6   �� 5      $
��106* �6   �� 5      $	��41* �6    � ColumnDefinitions 5   
   �� 5      .+�5   
   �� -   5         ��Name$ TitleWin��5      $��Upload Tree��6&     TitleWindows#��[ 69   $��0,0,0,26q�6_    �� TextAlignment$ Center=�6q   6�   �� 5   
   -   5        $
 Exit��5        	TitleExit#��[ 6"   6E   �� 5   
   $��	File Name��6   $��74,39,243,59q�6$   $
��Auto��6:   $��1��6G   6V   �� 5    
   -   5        	 ��Name$	 UT_FileName��5       $
��Left=�6'   $��25��6B   $��	71,72,0,0q�6N   
 �� TextWrapping$

 Wrap=�6a   $	��Top=�6u   $	��274��6�   $��1��6�   6�   �� 5"   
   -   5         ��Name$ FireFunction��5"      $��Upload Tree��6'     Button_Fire#��[ 6=   $��136,125,136,56q�6b   $��Center=�6z   $��Center=�6�   $��31��6�   $	��150��6�   $��1��6�   6�   �� 5$   
   $
��Left=�6   $��42��6/   $��
10,193,0,0q�6;   $	��Top=�6O   $	��400��6g   $��2��6s   $��1��6�   �� 5%   
   -   5        $ Comment��5%      $.��(File name must not include the extension��6%   $��2��6U   �� 5(   
   -   5         ��Name$ MyLoader��5(      ���	#E5000000$	��0,0q�5)      $��3��6"   $y�Hidden=�63   ._�5*      � .+�5+      � $	��425��6   .+�5,      �� $��We're loading the tree��6   $
��Auto��6=   $��118,114,103,228.2q�6J   �� 5-      $��Please wait...��6   $	��118��65   $��159,151,148,199.2q�6A   �� 5.      $+��%/PPC;component/Resaurce/hourglass.png��6   $��153,185,158,126.2q�6K   5/      50      52      53      58      