----seed cfg_user_role
insert into cfg_setting(name, value)
values('account lockout threshold', '5');


----seed cfg_user_role
insert into cfg_user_role(cfg_user_role_id, name, is_active)
values(1, 'Admin', TRUE);

insert into cfg_user_role(cfg_user_role_id, name, is_active)
values(2, 'Service Writer', TRUE);

insert into cfg_user_role(cfg_user_role_id, name, is_active)
values(3, 'Mechanic', TRUE);

insert into cfg_user_role(cfg_user_role_id, name, is_active)
values(4, 'Customer', TRUE);


----seed cfg_status
insert into cfg_status(cfg_status_id, description, display_order)
values(1, 'Pending', 1);

insert into cfg_status(cfg_status_id, description, display_order)
values(2, 'In Progress', 2);

insert into cfg_status(cfg_status_id, description, display_order)
values(3, 'On Hold', 3);

insert into cfg_status(cfg_status_id, description, display_order)
values(4, 'Completed', 4);

insert into cfg_status(cfg_status_id, description, display_order)
values(5, 'Canceled', 5);


----seed cfg_make
insert into cfg_make(cfg_make_id, name)
values(1, 'Ford');

insert into cfg_make(cfg_make_id, name)
values(2, 'Chevrolet');

insert into cfg_make(cfg_make_id, name)
values(3, 'Kia');


----seed cfg_model
insert into cfg_model(cfg_make_id, name)
values(1, 'F150');

insert into cfg_model(cfg_make_id, name)
values(1, 'F250');

insert into cfg_model(cfg_make_id, name)
values(1, 'Focus');

insert into cfg_model(cfg_make_id, name)
values(2, 'Colorado');

insert into cfg_model(cfg_make_id, name)
values(2, 'Malibu');

insert into cfg_model(cfg_make_id, name)
values(2, 'Silverado 1500');

insert into cfg_model(cfg_make_id, name)
values(3, 'Soul');

insert into cfg_model(cfg_make_id, name)
values(3, 'Sportage');

insert into cfg_model(cfg_make_id, name)
values(3, 'Carnival');


----seed account
insert into account(account_id, created_by, updated_by, first_name, last_name, is_active, username, password_hash, cfg_user_role_id)
values(1, 1, 1, 'Admin', 'User', TRUE, 'admin', 'admin', 1);

insert into account(account_id, created_by, updated_by, first_name, last_name, is_active, username, password_hash, cfg_user_role_id)
values(2, 1, 1, 'Seth', 'McFarland', TRUE, 'sfarl', 'password', 2);

insert into account(account_id, created_by, updated_by, first_name, last_name, is_active, username, password_hash, cfg_user_role_id)
values(3, 1, 1, 'Jared', 'Kirkland', TRUE, 'jkirk', 'password', 3);

insert into account(account_id, created_by, updated_by, first_name, last_name, is_active, username, password_hash, cfg_user_role_id)
values(4, 1, 1, 'Jacob', 'Vargo', TRUE, 'jvarg', 'password', 4);


----seed vehicle
insert into vehicle(vehicle_id, created_by, updated_by, account_id, cfg_model_id, year, color)
values(1, 1, 1, 4, 1, 2026, 'Black');

insert into vehicle(vehicle_id, created_by, updated_by, account_id, cfg_model_id, year, color)
values(2, 1, 1, 4, 4, 2024, 'Blue');


----seed work_order
insert into work_order(work_order_id, created_by, updated_by, account_id, vehicle_id, cfg_status_id, description)
values(1, 1, 1, 4, 1, 1, 'Tire Change');


----seed work_order_expense
insert into work_order_expense(created_by, updated_by, work_order_id, cfg_status_id, description, amount)
values(1, 1, 1, 1, 'Labor', 54.45);

insert into work_order_expense(created_by, updated_by, work_order_id, cfg_status_id, description, amount)
values(1, 1, 1, 1, 'Tires x4', 212.24);

insert into work_order_expense(created_by, updated_by, work_order_id, cfg_status_id, description, amount)
values(1, 1, 1, 1, 'Administrative Fee', 15);
