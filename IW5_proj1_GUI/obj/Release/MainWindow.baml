   M S B A M L   `   `   `  ����   IW5_proj1_GUI     IW5_proj1_GUI.CustomerList   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml       � Title$  Customer List��$	��650�� � 
ResizeMode$ NoResize=�$	��700��$	��700��$	��750��$	��650��.��� .+�o� $��25��$	��Top=�.@�m� $��	_Customer��.@�m� -   $��CustomerMenuItemAdd��$��_Add...��m� -   $��CustomerMenuItemEdit��$��_Edit selected...��m� $��_Contact��.@�m� -   $��
contactAdd��$��_Add...��m� -   $��contactEdit��$��_Edit selected...���� �� -    ��Name$ customersFromFile��$��10,49,0,231q�$	��659�� �� SelectionMode$ Single=�$
��Left=�$��Stretch=�����  �� View �� .P��� $
��Name�� �� Width$ 60�� �� CellTemplate �� .R���  ��Name$ cellName������ *Name+�� $��Surname��$ 80�� �� .R��� $ cellSurname������ *	Surname+�� $	��Sex��$ 40�� �� .R��� $ cellSex������ *Sex+�� $	��Age��$ 40�� �� .R��� $ cellAge������ *Age+�� $��Street��$	 120�� �� .R��� $ 
cellStreet������ *Street+�� $
��City��$	 100�� �� .R��� $ cellCity������ *City+�� $��Zipcode��$ 50�� �� .R��� $ cellZipcode������ *	Zipcode+�� $��Country��$ 80�� �� .R��� $ cellCountry������ *	Country+�� $�� ��$ 30�� �� .R��� $��checkBoxDelete��-    d� 	IsChecked �� 	 �� RelativeSource	 �� 
 �� AncestorType"
 �� �� Path$ 
IsSelected��� -   $ contactsView��$��10,448,0,40q�$	��659��$ Single=�$
��Left=�$��Stretch=�����  �� .P��� $��E-mail��$	 160�� �� .R��� $ 	cellEmail������ *Email+�� $��Phone��$	 100�� �� .R��� $ 	cellPhone������ *Phone+�� -   $��buttonDelete��$��25��$	��Top=�$��Right=�$	��100��$��
0,388,15,0q� J� RenderTransformOrigin$ 0.478,-0.089&�$��Delete Customer��$��Center=��� -	   $��checkBoxMultiSelect��$��Right=�$��0,390,122,0q�$	��Top=�$ FalseY�$	��149��.���� $
��Wrap=�$	��139��Multiple selection mode�� $��Person Information��$
��Left=�$��7,25,0,0q�$	��Top=��� $ ��Person Contact Information��$
��Left=�$��
10,422,0,0q�$	��Top=��� -
    ��Name$ buttonDeleteContact��$��25��$	��Top=�$��Right=�$	��100��$��
0,581,15,0q�$ 0.478,-0.089&�$��Delete Contact��$��Center=��� -   $��txtBoxFilter��$
��Left=�$��25��$��
10,388,0,0q� �� TextWrapping$
 Wrap=�$��Insert filter data��$	��Top=�$	��100���� -   $��comboBoxFilter��$
��Left=�$��115,388,0,0q�$	��Top=�$	��120��$��25�� �� SelectedIndex$ 1��.@��� .��Filter by Name�� .��Filter by Surname