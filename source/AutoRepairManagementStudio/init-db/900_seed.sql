----seed cfg_user_role
insert into cfg_setting(name, value)
values('account lockout threshold', '5');


----seed cfg_user_role
insert into cfg_user_role(name, is_active)
values('Admin', TRUE);

insert into cfg_user_role(name, is_active)
values('Service Writer', TRUE);

insert into cfg_user_role(name, is_active)
values('Mechanic', TRUE);

insert into cfg_user_role(name, is_active)
values('Customer', TRUE);


----seed cfg_status
insert into cfg_status(description, display_order)
values('Pending', 1);

insert into cfg_status(description, display_order)
values('In Progress', 2);

insert into cfg_status(description, display_order)
values('On Hold', 3);

insert into cfg_status(description, display_order)
values('Completed', 4);

insert into cfg_status(description, display_order)
values('Canceled', 5);


----seed cfg_vehicle_model
insert into cfg_vehicle_model(make, model)
values('Ford', 'F150');

insert into cfg_vehicle_model(make, model)
values('Ford', 'F250');

insert into cfg_vehicle_model(make, model)
values('Ford', 'Focus');

insert into cfg_vehicle_model(make, model)
values('Chevrolet', 'Colorado');

insert into cfg_vehicle_model(make, model)
values('Chevrolet', 'Malibu');

insert into cfg_vehicle_model(make, model)
values('Chevrolet', 'Silverado 1500');

insert into cfg_vehicle_model(make, model)
values('Kia', 'Soul');

insert into cfg_vehicle_model(make, model)
values('Kia', 'Sportage');

insert into cfg_vehicle_model(make, model)
values('Kia', 'Carnival');


----seed account
insert into account(created_by, updated_by, first_name, last_name, is_active, username, password_hash, cfg_user_role_id)
values(1, 1, 'Admin', 'User', TRUE, 'admin', 'admin', 1);

insert into account(created_by, updated_by, first_name, last_name, is_active, username, password_hash, cfg_user_role_id)
values(1, 1, 'Seth', 'McFarland', TRUE, 'sfarl', 'password', 2);

insert into account(created_by, updated_by, first_name, last_name, is_active, username, password_hash, cfg_user_role_id)
values(1, 1, 'Jared', 'Kirkland', TRUE, 'jkirk', 'password', 3);

insert into account(created_by, updated_by, first_name, last_name, is_active, username, password_hash, cfg_user_role_id)
values(1, 1, 'Jacob', 'Vargo', TRUE, 'jvarg', 'password', 4);


----seed vehicle
insert into vehicle(created_by, updated_by, account_id, cfg_vehicle_model_id, year, color)
values(1, 1, 4, 1, 2026, 'Black');

insert into vehicle(created_by, updated_by, account_id, cfg_vehicle_model_id, year, color)
values(1, 1, 4, 4, 2024, 'Blue');


----seed work_order
insert into work_order(created_by, updated_by, account_id, vehicle_id, cfg_status_id, description)
values(1, 1, 4, 1, 1, 'Tire Change');


----seed work_order_expense
insert into work_order_expense(created_by, updated_by, work_order_id, cfg_status_id, description, amount)
values(1, 1, 1, 1, 'Labor', 54.45);

insert into work_order_expense(created_by, updated_by, work_order_id, cfg_status_id, description, amount)
values(1, 1, 1, 1, 'Tires x4', 212.24);

insert into work_order_expense(created_by, updated_by, work_order_id, cfg_status_id, description, amount)
values(1, 1, 1, 1, 'Administrative Fee', 15);
