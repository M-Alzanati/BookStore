# Mult-tenant bookstore


![Build Status](https://travis-ci.org/joemccann/dillinger.svg?branch=master)

Welcome to bookstore multi-tenant app, this app using mysql database with two context, one for data, other for identity.
---

* This app is using mult-tenant apporach to with single database and shared schema.
* App have 2 options to identify tenant, (Host, Query).
* Currenlty i'm using Query based identification service.

# The Following Digram shows the tenant apporach

![alt text](https://github.com/M-Alzanati/BookStore/blob/master/service.PNG)


* Every Enitiy Contains a tenant id to represent which tenant this record belongs
* Add the TenantService as an extension method to IServiceCollection 

License
----

MIT
 [My Email]: mohamed.h.alzanaty@gmail.com
