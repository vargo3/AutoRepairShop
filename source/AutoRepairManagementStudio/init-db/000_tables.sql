
CREATE TABLE public.cfg_setting (
    name VARCHAR(64) NOT NULL PRIMARY KEY,
    value VARCHAR(64) NULL
);

CREATE TABLE public.cfg_user_role (
    cfg_user_role_id INT NOT NULL GENERATED ALWAYS AS IDENTITY PRIMARY KEY,

    name VARCHAR(64) NOT NULL,
    is_active BOOLEAN NOT NULL
);

CREATE TABLE public.cfg_vehicle_model (
    cfg_vehicle_model_id INT NOT NULL GENERATED ALWAYS AS IDENTITY PRIMARY KEY,

    make VARCHAR(64) NOT NULL,
    model VARCHAR(64) NOT NULL
);

CREATE TABLE public.cfg_status (
    cfg_status_id INT NOT NULL GENERATED ALWAYS AS IDENTITY PRIMARY KEY,

    description VARCHAR(24) NOT NULL UNIQUE,
    display_order INT NOT NULL
);

CREATE TABLE public.account (
    account_id INT NOT NULL GENERATED ALWAYS AS IDENTITY PRIMARY KEY,

    created_at TIMESTAMPTZ NOT NULL DEFAULT CURRENT_TIMESTAMP,
    created_by INT NOT NULL,
    updated_at TIMESTAMPTZ NOT NULL DEFAULT CURRENT_TIMESTAMP,
    updated_by INT NOT NULL,
    first_name VARCHAR(64) NOT NULL,
    last_name VARCHAR(64) NOT NULL,
    is_active BOOLEAN NOT NULL,
    username VARCHAR(64) NOT NULL UNIQUE,
    password_hash VARCHAR(64) NULL,
    password_attempt_count INT NOT NULL DEFAULT 0,
    is_locked BOOLEAN NOT NULL DEFAULT FALSE,
    locked_at TIMESTAMPTZ NULL,
    phone VARCHAR(20) NULL,
    email VARCHAR(64) NULL UNIQUE,
    cfg_user_role_id INT NOT NULL,
    
    CONSTRAINT fk_account__created_by FOREIGN KEY(created_by) REFERENCES account(account_id),
    CONSTRAINT fk_account__updated_by FOREIGN KEY(updated_by) REFERENCES account(account_id)
);

CREATE TABLE public.vehicle (
    vehicle_id INT NOT NULL GENERATED ALWAYS AS IDENTITY PRIMARY KEY,

    created_at TIMESTAMPTZ NOT NULL DEFAULT CURRENT_TIMESTAMP,
    created_by INT NOT NULL,
    updated_at TIMESTAMPTZ NOT NULL DEFAULT CURRENT_TIMESTAMP,
    updated_by INT NOT NULL,
    account_id INT NOT NULL,
    --cfg_make_id INT NOT NULL, --redundant since we can get the make from the model, but it is helpful for filtering and reporting
    cfg_vehicle_model_id INT NOT NULL,
    year SMALLINT NOT NULL,
    color VARCHAR(32) NOT NULL,
    vin CHAR(17) NULL UNIQUE,
    license_plate VARCHAR(15) NULL UNIQUE,
    
    CONSTRAINT fk_vehicle__created_by FOREIGN KEY(created_by) REFERENCES account(account_id),
    CONSTRAINT fk_vehicle__updated_by FOREIGN KEY(updated_by) REFERENCES account(account_id),
    CONSTRAINT fk_vehicle__account_id FOREIGN KEY(account_id) REFERENCES account(account_id),
    --CONSTRAINT fk_vehicle__cfg_make_id FOREIGN KEY(cfg_make_id) REFERENCES cfg_make(cfg_make_id),
    CONSTRAINT fk_vehicle__cfg_vehicle_model_id FOREIGN KEY(cfg_vehicle_model_id) REFERENCES cfg_vehicle_model(cfg_vehicle_model_id)
);

CREATE TABLE public.work_order (
    work_order_id INT NOT NULL GENERATED ALWAYS AS IDENTITY PRIMARY KEY,

    created_at TIMESTAMPTZ NOT NULL DEFAULT CURRENT_TIMESTAMP,
    created_by INT NOT NULL,
    updated_at TIMESTAMPTZ NOT NULL DEFAULT CURRENT_TIMESTAMP,
    updated_by INT NOT NULL,
    account_id INT NOT NULL, --vehicle's can be sold, so we want to keep the work order history with both the user and the vehicle
    vehicle_id INT NOT NULL,
    cfg_status_id INT NOT NULL,
    description VARCHAR(64) NULL,
    notes VARCHAR(512) NULL,
    
    CONSTRAINT fk_work_order__created_by FOREIGN KEY(created_by) REFERENCES account(account_id),
    CONSTRAINT fk_work_order__updated_by FOREIGN KEY(updated_by) REFERENCES account(account_id),
    CONSTRAINT fk_work_order__cfg_status_id FOREIGN KEY(cfg_status_id) REFERENCES cfg_status(cfg_status_id),
    CONSTRAINT fk_work_order__account_id FOREIGN KEY(account_id) REFERENCES account(account_id),
    CONSTRAINT fk_work_order__vehicle_id FOREIGN KEY(vehicle_id) REFERENCES vehicle(vehicle_id)
);

CREATE TABLE public.work_order_expense (
    work_order_expense_id INT NOT NULL GENERATED ALWAYS AS IDENTITY PRIMARY KEY,

    created_at TIMESTAMPTZ NOT NULL DEFAULT CURRENT_TIMESTAMP,
    created_by INT NOT NULL,
    updated_at TIMESTAMPTZ NOT NULL DEFAULT CURRENT_TIMESTAMP,
    updated_by INT NOT NULL,
    work_order_id INT NOT NULL,
    cfg_status_id INT NOT NULL,
    description VARCHAR(64) NOT NULL,
    amount numeric(12, 2) NOT NULL,
    performed_at TIMESTAMPTZ NULL,
    performed_by_id INT NULL,
    notes VARCHAR(512) NULL,

    CONSTRAINT fk_work_order_expense__created_by FOREIGN KEY(created_by) REFERENCES account(account_id),
    CONSTRAINT fk_work_order_expense__updated_by FOREIGN KEY(updated_by) REFERENCES account(account_id),
    CONSTRAINT fk_work_order_expense__cfg_status_id FOREIGN KEY(cfg_status_id) REFERENCES cfg_status(cfg_status_id),
    CONSTRAINT fk_work_order_expense__performed_by_id FOREIGN KEY(performed_by_id) REFERENCES account(account_id)
);
