import csv
import smtplib
import pandas as pd
from email.mime.multipart import MIMEMultipart
from email.mime.text import MIMEText

#Info of my gmail 
my_address = input("Please type in your email address: ")
my_password = input("Please type in your pasword: ")

#create the message
from string import Template
def read_msg(filename):
    with open(filename, 'r', encoding = 'utf-8') as file:
        file_content = file.read()
    return file_content 
 
#make a list of address and passwords
def get_contacts(): #for example we have the simplest list generated from the seating chart like this with mixed students. 
                    #True means we will send email, false means we will not
    info = [
        ("minh", "huynhngocminh99@gmail.com", True),
        ("andrew", "abaker@angelo.edu", False),
        ("nam", "nanashi1906@gmail.com", False)
    ]
    df = pd.DataFrame(info, columns=['name', 'email address', 'risk'])
    listName = []
    for index in range(len(df['risk'])):
        if(df['risk'][index]) == True:
            #print(df['name'][index], df['email address'][index])
            a = '{} {}'.format(df['name'][index], df['email address'][index])
            listName.append(a)
    return listName
    


def main():
    #get the message and contact
    ori_mesage = read_msg(r"C:\Users\huynh\OneDrive\Máy tính\message.txt") #replace this location by the location of the text file that you downloaded
    name_list = get_contacts()
    
    #log in
    s = smtplib.SMTP('smtp-mail.outlook.com',587)
    s.ehlo()
    s.starttls()
    s.ehlo()
    s.login(my_address, my_password)

    
    #get the address and password
    
    for i in name_list:
        name, email_address = i.split()
        msg = MIMEMultipart()# create a message
        
        # replace the filler name by the person name 
        message = ori_mesage.replace('PERSON_NAME', name)
        #set the sender and receiver email addresses, and set the header
        msg['From'] = my_address
        msg['To'] = email_address
        msg['Subject'] = "Alert, covid19"
        #attach the message
        msg.attach(MIMEText(message))
        #send email
        s.sendmail(my_address,email_address,msg.as_string())
    

    
    # Terminate the SMTP session and close the connection
    s.quit()
if __name__ == '__main__':
    main()