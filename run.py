import argparse
import base64
import os
import requests

def parse_args() -> argparse.Namespace:
    parser = argparse.ArgumentParser(description="Insert a release into the Crooked Cactus DB")
    parser.add_argument("--username", dest="username", required=True, help="Username for Crooked Cactus")
    parser.add_argument("--password", dest="password", required=True, help="Password for Crooked Cactus")
    parser.add_argument("--host", dest="host", required=True, help="Host for Crooked Cactus")
    parser.add_argument("--file_data", dest="file_data", required=True, help="File data to be uploaded")
    parser.add_argument("--version", dest="version", required=True, help="Current file version")
    parser.add_argument("--product_id", dest="product_id", required=True, help="Product ID")
    parser.add_argument("--stage_id", dest="stage_id", required=True, help="Development stage ID")
    parser.add_argument("--arguments", dest="arguments", required=True, help="Application arguments")

    return parser.parse_args()

def get_access_token(args: argparse.Namespace) -> str:
    response = requests.post(f"{args.host}/api/auth/login", data={ 'username': args.username, 'password': args.password })
    return response.json()['access_token']

def upload_release(args: argparse.Namespace, token: str):
    header = {
        'Authorize': f'Bearer {token}'
    }


    response = requests.post(f"{args.host}/api/auth/login", headers=header, data={ 'username': args.username, 'password': args.password })
    return response.json()['access_token']
