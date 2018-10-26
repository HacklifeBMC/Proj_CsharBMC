# Proj_C# BMC
Presentation project for C# developer interview.
Copy right 2018


Problem Statement


    Blood banks provide a vital service. People give blood to these banks, and in turn, this blood is used by patients in need of blood. People need blood for a variety of reasons and blood banks are incredibly important. Every two seconds someone is in need of blood according to the American Red Cross.  People have specific blood types, which determine who they can give blood to and receive blood from. AB+ blood types are the universal receivers (can receive blood from anyone) and O- blood types are the universal donors (can donate blood to anyone). We have created a database by which donors, banks, and patients can be found along with important information about each group, such as disease, blood type, etc.
    In our first project, we created an ERD and schema for blood banks. In this project, we have refined our schema to meet the standards of BCNF. We have converted our queries into SQL and brought our database to life using Visual Studio, including a GUI. We have also expanded our schema to provide more information.

Functional Dependencies and Schema Refinement

Patients(pname: string, pid: string, ptype: string, pdisease: string, paddress: String)

Since all the attributes in this table are solely related by the primary key (pid), this table is already in BCNF. Multiple patients can have the same name (pname), blood type (ptype), and disease (pdisease), so these are not keys. Functional dependency:

pid → (pname, ptype, pdisease)

Donors (dname: string, did: string, dtype: string, dmedrep: string, daddress: string, dcontact: string)

Since all the attributes in this table are solely related by the primary key (did), this table is already in BCNF. Multiple donors can have the same name (dname), blood type (dtype), medical report (dmedrep), address (dadress), contact (dcontact), and disease (ddisease), so these are not keys. Functional dependency:

did → (dname, dtype, dmedrep, daddress, dcontact)


Bank (BankID: int, bname: string, bcontact: string,baddress: string)

After receiving input from one of our TAs, we have decided that the structure provided for first project was inadequate, because it fails to provide a date for donations and receiving blood. The best way to address this is by putting this information in relation tables for donated blood and received blood. These tables would look like this:

Receive_Blood(RecID: int, date: string)

Given_Blood(DonationID: int, date: string)

The keys in these tables would be the ID of the donation or reception. The functional dependencies are displayed below:


rid→ date
ddid → date

We also much change our Bank schema, which had been functioning as these tables above. Updated below:

Bank(bid: string, bcontact: string, bname: string, baddress: string)

We have added a bid, which can act as a key for the bank. Since multiple banks can have the same contact, name, and address and bid is the primary key, this is already in BCNF. FD:

bid→ bcontact, bname, baddress
