   M S B A M L   `   `   `  ����G  CTGraphingApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:TGraphingAppTGraphingApp  5   	   =#clr-namespace:TGraphingApp.CommandsTGraphingApp.Commands  5   	   7 clr-namespace:TGraphingApp.ViewsTGraphingApp.Views  5	   	       TGraphingApp.MainWindow   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ,localclr-namespace:TGraphingApp     5   	   7command#clr-namespace:TGraphingApp.Commands     5   	   1view clr-namespace:TGraphingApp.Views     5	   	   -   5          �Name$  WindowInstance��5   	   $	��450��5   b   $	��800��6o    � Title 6	   �� *PreferredTitle+ �� Mode$ OneWay=� �� RelativeSource ��  �� Mode$
 Self=� J� CommandBindings 5      )  #System.Windows.Input.CommandBinding  5   
   -   5           Command$) #command:MainWindowCommands.NewScene��5      6k     5   
   -   5        $* $command:MainWindowCommands.OpenScene��5      6l     5   
   -   5        $* $command:MainWindowCommands.SaveScene��5      6l     5   
   -   5        $, &command:MainWindowCommands.SaveSceneAs��5      6n     5   
   -   5        $) #command:MainWindowCommands.ScrollIn��5      6k     5   
   -   5        $* $command:MainWindowCommands.ScrollOut��5      6l   .��5      ]� $��Stretch=�6   $��Stretch=�6.   #��� ��6J   .+�5   
   o� $	��Top=�6   $��20��6$   #��� ��60   .@�5      m� $��Scene��6   .@�5      m� $	��New��6    m� Command$) #command:MainWindowCommands.NewScene��6(   m� 5      $
��Open��6   $* $command:MainWindowCommands.OpenScene��6)   m� 5      $
��Save��6   $* $command:MainWindowCommands.SaveScene��6)   m� 5      $��	Save as..��6   $, &command:MainWindowCommands.SaveSceneAs��6.   5      m� 5      $
��Edit��6   .@�5      m� $
��Undo��6   $% command:MainWindowCommands.Undo��6)   m� 5      $
��Redo��6   $% command:MainWindowCommands.Redo��6)   5      m� 5       $
��View��6   .@�5!      m� $��	Scroll In��6   $) #command:MainWindowCommands.ScrollIn��6.   6^   m� 5"      $��
Scroll Out��6   $* $command:MainWindowCommands.ScrollOut��6/   6`   5#      m� 5$      $��About��6   6(   m� 5%      $
��Help��6   6'   5&      � 5'   
   #��� ��6   $��0 1 0 0q�6^    � ColumnDefinitions 5(      �� 5)      $	��250��6#   $	��250 �62   �� 5*      $
��Auto �6#   �� 5+      $��1* �6#   .+�5-      "   TGraphingApp.Views.SceneView  -   5        	  Name$	 	ViewScene��5-      $��0��60   $��Stretch=�6@   
 � DataContext
 6\   �� *CurrentScene+�� 5.      $��1��6   $��Stretch=�6+   $��3��6G   ���#DDDDDD �� ResizeDirection$ Columns=�6f    �� ResizeBehavior$ PreviousAndNext=�6�   "   TGraphingApp.Views.GraphView  5/      -	   5          Name$ 	ViewGraph��5/      $��2��60   $��Stretch=�6@   50      51      52      