-- Script Name: 002.add_overtime_errors_table.sql
-- Script author: Juan Fernando Acevedo 
-- Script date: 05/06/2026

CREATE TABLE IF NOT EXISTS public.overtime_errors
(
    id uuid NOT NULL DEFAULT uuid_generate_v4(),
    employee_document character varying(20) COLLATE pg_catalog."default",
    overtime_type character varying(50) COLLATE pg_catalog."default",
    hours character varying(50) COLLATE pg_catalog."default",
    report_date character varying(50) COLLATE pg_catalog."default",
    error_message text COLLATE pg_catalog."default" NOT NULL,
    processed_at timestamp without time zone DEFAULT CURRENT_TIMESTAMP,
    CONSTRAINT overtime_errors_pkey PRIMARY KEY (id)
)