{
    "metadata": {
        "kernelspec": {
            "name": "SQL",
            "display_name": "SQL",
            "language": "sql"
        },
        "language_info": {
            "name": "sql",
            "version": ""
        }
    },
    "nbformat_minor": 2,
    "nbformat": 4,
    "cells": [
        {
            "cell_type": "code",
            "source": [
                "Select p.FullName\r\n",
                "From Application.People p;"
            ],
            "metadata": {
                "azdata_cell_guid": "1ac38388-d5e9-486e-863e-58d8616623b4",
                "language": "sql",
                "tags": []
            },
            "outputs": [
                {
                    "output_type": "error",
                    "evalue": "Msg 208, Level 16, State 1, Line 1\r\nInvalid object name 'Application.People'.",
                    "ename": "",
                    "traceback": []
                },
                {
                    "output_type": "display_data",
                    "data": {
                        "text/html": "Total execution time: 00:00:00.063"
                    },
                    "metadata": {}
                }
            ],
            "execution_count": 1
        }
    ]
}