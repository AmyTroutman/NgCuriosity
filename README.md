# NgCuriosity
Just a project for trying new Angular things.

### Styling
Trying to do something different. I like the b&w bg-img with transparent colored tiles all over, but I want to do try to get away from that. At the moment (Oct 28, 2020), I'm still doing the stained glass thing. It just happened. 

## First Project: FullCalendar
Using [FullCalendar](https://fullcalendar.io/docs/angular) to mess around with a planner-type thing. 

- [x] update to Angular 9
- [x] npm install --save @fullcalendar/angular 
- [x] npm install plugins
- [x] Import FullCalendar Module 
- [x] import plugins 
- [x] register plugins
- [x] Setup backend 
- [x] Migrate
- [x] Test API in Postman
- [ ] Make an interface!!
- [ ] Make Event API service
- [ ] Make Event service

### Notes
  You can update a remote database when these fire:
    eventAdd:
    eventChange:
    eventRemove:

  Made some models and controllers. Haven't tested yet.

### Issues
  - ~~Angry about getting members and events~~

## Second Project: Expandable MatTable
A catalog for all the hot bevs I have consumed. Coffee, tea, cocoa, etc.
- Default view will display Brand, Name, Type, Subtype, Mood
- Expanded view will display Image, Review
[Expandable MatTable](https://v9.material.angular.io/components/table/examples)

- [x] ng add Material
- [x] Make model
- [x] Make controller
- [x] Migrate
- [x] Test API in Postman
- [x] Make an interface!
- [x] Make HotBev service
- [ ] Make HotBev API service (wtf was I talking about here?)
- [x] DrinKeep component
- [x] Add link in nav-menu
- [ ] Add CaffeineLvl to model?
- [ ] And a Mat Slider for caffeineLvl!
- [ ] Add ImageUrl property
- [x] Expandable MatTable
- [ ] NewBev component
- [ ] Use chips as selectors for type and subtype
- [ ] Btn to remove a bev
- [ ] Way to edit bev

### Notes
Caffeine amounts (6oz cup)
Black tea: 50mg
Oolong tea: 30-40mg
Green tea: 20-30mg
White tea: 15-20mg
Decaf black tea: 2mg


Brewed coffee: 80-135mg
Drip coffee: 115-175mg
Decaf: 2mg
*Caffeine levels vary depending on roast, grind, bean type, and brewing method. French press extracts more caffeine from a dark roast. Percolator and espresso extract more from a light roast. Robusta has more caffeine than arabica. 

### Issues
MatTable not updating properly when an item is deleted(see [stackoverflow](https://stackoverflow.com/questions/49284358/calling-renderrows-on-angular-material-table))

## Image Credits
[Carlos Quintero](https://unsplash.com/@c_quintero) - [“Falling Through Infinity”](https://unsplash.com/photos/7mINv5udhe8)
[Benjah-bmm27](https://commons.wikimedia.org/wiki/User:Benjah-bmm27) - ["Skeletal formula for caffeine"](https://commons.wikimedia.org/w/index.php?curid=1878332)  - Own work, Public Domain

