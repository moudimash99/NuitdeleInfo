import functools

from flask import (
    Blueprint, flash, g, redirect, render_template, request, session, url_for
)


test2bp = Blueprint('test', __name__, url_prefix='/auth')


@app.route('/hello2')
def hello2():
    response = make_response('Hello 2 from Flask!', 200)
    response.mimetype = "text/plain"
    return response



