﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AddressBook.cs" company="Bridgelabz">
//   Copyright © 2018 Company
// </copyright>
// <creator Name="Dheer Singh Meena"/>
// --------------------------------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace AddressBookSystemCollection
{
    class Program
    {
        static void Main(string[] args)
        {
            int choice = 0;
            //Creating a method of class AddressBook
            AddressBook ab = new AddressBook();
            // Using Do-While Loop to iterate the options give to user.
            do
            {
                //Asking the user choice
                Console.WriteLine("Enter your choice :");
                Console.WriteLine("1. Add Contact.");
                Console.WriteLine("2. View all Contacts.");
                Console.WriteLine("3.Edit existing contacts.");
                Console.WriteLine("4.Remove a contact.");
                Console.WriteLine("5.View AddressBook fora key name.");
                Console.WriteLine("6.Search person by city/state name.");
                Console.WriteLine("7.View persons by city.");
                Console.WriteLine("8.View persons by state");
                Console.WriteLine("9.To get count of contacts present in a city");
                Console.WriteLine("10.To get count of contacts present in a state");
                Console.WriteLine("11.Exit.");
                choice = Convert.ToInt32(Console.ReadLine());
                //Checking the choice entered by the user and iterating using for loop
                if (choice == 1)
                {
                    //asking for the name of the user
                    Console.WriteLine("Enter your Name : ");
                    string name = Console.ReadLine();
                    //Regex for checking name
                    Regex reg4 = new Regex(@"(^[a-z A-Z]*$)");
                    //if regex is not matching then asking for valid name
                    while (!reg4.IsMatch(name))
                    {
                        Console.WriteLine("Enter a valid name : ");
                        name = Console.ReadLine();
                    }
                    //checking for duplicate entry
                    while (ab.UC7_CheckForDuplicateEntry(name))
                    {
                        Console.WriteLine("This name already exists in the address book.");
                        Console.WriteLine("Please enter a new name : ");
                        name = Console.ReadLine();
                        while (!reg4.IsMatch(name))
                        {
                            Console.WriteLine("Enter a valid name : ");
                            name = Console.ReadLine();
                        }
                    }
                    //asking for address of the user
                    Console.WriteLine("Enter your address : ");
                    string address = Console.ReadLine();
                    //regex for checking the address field
                    Regex reg5 = new Regex(@"(^[a-z A-Z]*$)");
                    //if regex is not matching then asking for valid address
                    while (!reg5.IsMatch(address))
                    {
                        Console.WriteLine("Enter a valid address : ");
                        address = Console.ReadLine();
                    }
                    //asking to enter city name by the user
                    Console.WriteLine("Enter your city : ");
                    string city = Console.ReadLine();
                    //regex to match city name
                    Regex reg6 = new Regex(@"(^[a-z A-Z]*$)");
                    //if regex is not matching then asking for valid city name
                    while (!reg6.IsMatch(city))
                    {
                        Console.WriteLine("Enter a valid city name : ");
                        city = Console.ReadLine();
                    }
                    //asking to enter state name of the user
                    Console.WriteLine("Enter your state : ");
                    string state = Console.ReadLine();
                    //regex to check the correct state name
                    Regex reg7 = new Regex(@"(^[a-z A-Z]*$)");
                    //if regex is not matching then asking for the correct state name
                    while (!reg7.IsMatch(state))
                    {
                        Console.WriteLine("Enter a valid state name : ");
                        state = Console.ReadLine();
                    }
                    //asking for the Zip code of the user
                    Console.WriteLine("Enter your zip : ");
                    string zip = Console.ReadLine();
                    //regex to match the correct zip code format
                    Regex reg = new Regex(@"(^[0-9]{6}$)");
                    //if zip code is not matching then asking for valid zip code
                    while (!reg.IsMatch(zip))
                    {
                        Console.WriteLine("Enter a valid zip code : ");
                        zip = Console.ReadLine();
                    }
                    //asking for the contact number of the user
                    Console.WriteLine("Enter your contact no. : ");
                    string contactNo = Console.ReadLine();
                    //regex code to match the correct contact number format
                    Regex reg1 = new Regex(@"(^[7-9]{1}[0-9]{9}$)");
                    //if phone number doesn't matches then asking for valid number
                    while (!reg1.IsMatch(contactNo))
                    {
                        Console.WriteLine("Enter a a valid mobile number : ");
                        contactNo = Console.ReadLine();
                    }
                    //asking for the email id of the user
                    Console.WriteLine("Enter your email : ");
                    string mailID = Console.ReadLine();
                    //regex code to match the email id 
                    Regex reg2 = new Regex("^[0-9A-Za-z]+([+-_.][a-zA-Z]+)*[@][0-9A-Za-z]+[.][0-9A-Za-z]{2,3}$");
                    //if the email id not matches with the regex pattern then asking for valid email id
                    while (!reg2.IsMatch(mailID))
                    {
                        Console.WriteLine("Enter a a valid emailID : ");
                        mailID = Console.ReadLine();
                    }
                    //asking for the keyname to be saved in the address book
                    Console.WriteLine("Enter the key name to be saved in the address book : ");
                    string keyname = Console.ReadLine();
                    //regex pattern to match the keyname
                    Regex reg3 = new Regex("^[A-Z a-z]*$");
                    //if keyname doesn't matches then asking for a valid keyname
                    while (!reg3.IsMatch(keyname))
                    {
                        Console.WriteLine("Enter a valid name : ");
                        keyname = Console.ReadLine();
                    }
                    //storing all the data entered by the user in the constructor
                    Contact c = new Contact(name, address, city, state, zip, contactNo, mailID);
                    //adding the details into the method AddAddress
                    ab.AddAddress(keyname, c);

                }
                //second choice iteration of view all contacts
                else if (choice == 2)
                {
                    //creating an object of ViewAddressBook and storing in list li
                    List<Contact> li = ab.ViewAddressBook();
                    //checking if the list is empty or not
                    if (li.Count == 0)
                    {
                        Console.WriteLine("The address book is empty.");
                    }
                    else
                    {
                        //iterating each data of the list using foreach loop
                        foreach (Contact cl in li)
                        {
                            Console.WriteLine("Name : " + cl.GetName());
                            Console.WriteLine("Address : " + cl.GetAddress());
                            Console.WriteLine("City : " + cl.GetCity());
                            Console.WriteLine("State : " + cl.GetState());
                            Console.WriteLine("zip : " + cl.GetZip());
                            Console.WriteLine("Contact No. : " + cl.GetPhoneNo());
                            Console.WriteLine("Email ID : " + cl.GetEmail());
                        }
                    }
                }
                //iterating third choice to edit existing contact
                else if (choice == 3)
                {
                    Console.WriteLine("Enter the name :");
                    string ename = Console.ReadLine();
                    Console.WriteLine("Enter the new number for " + ename);
                    string newnumber = Console.ReadLine();
                    ab.EditNumber(ename, newnumber);
                }
                //iterating fourth choice to delete contact
                else if (choice == 4)
                {
                    Console.WriteLine("Enter the name :");
                    string rname = Console.ReadLine();
                    ab.RemoveContact(rname);
                }
                //iterating fifth choice to view address book by a key name
                else if (choice == 5)
                {
                    Console.WriteLine("Enter the key name : ");
                    string kname = Console.ReadLine();
                    //adding the keyname 
                    Contact cc = ab.ViewByKeyName(kname);
                    if (cc == null)
                    {
                        Console.WriteLine("No such key name found!!!");
                    }
                    else
                    {
                        Console.WriteLine("Name : " + cc.GetName());
                        Console.WriteLine("Address : " + cc.GetAddress());
                        Console.WriteLine("City : " + cc.GetCity());
                        Console.WriteLine("State : " + cc.GetState());
                        Console.WriteLine("zip : " + cc.GetZip());
                        Console.WriteLine("Contact No. : " + cc.GetPhoneNo());
                        Console.WriteLine("Email ID : " + cc.GetEmail());
                    }
                }
                //iterating sixth choice to search people by city or state
                else if (choice == 6)
                {
                    Console.WriteLine("Enter the name of the city/state : ");
                    string location = Console.ReadLine();
                    //calling the method SearchPeopleByCityOrState() and adding the location into the list li
                    List<Contact> li = ab.SearchPeopleByCityOrState(location);
                    //iterating the list to fetch the contact details when the list count is not empty
                    if (li.Count != 0)
                    {
                        Console.WriteLine("There are " + li.Count + " contacts with location " + location);
                        foreach (Contact cc in li)
                        {
                            Console.WriteLine("Name : " + cc.GetName() + "  Address : " + cc.GetAddress() + "  ZIP : " + cc.GetZip() + "  Contact No : " + cc.GetPhoneNo() + "  EmailID : " + cc.GetEmail());
                        }
                    }
                    else
                    {
                        Console.WriteLine("No contact found!!!");
                    }
                }
                //UC9- View persons by city or state
                else if (choice == 7)
                {
                    ab.AddressByCity();
                }
                else if (choice == 8)
                {
                    ab.AddressByState();
                }
                //UC10-Count by city name
                else if (choice == 9)
                {
                    ab.GetCountByCity();
                }
                //UC10-Count by state name
                else if (choice == 10)
                {
                    ab.GetCountByState();
                }
                else
                {
                    break;
                }
                //exit
            } while (choice != 11);
        }
    }
}
