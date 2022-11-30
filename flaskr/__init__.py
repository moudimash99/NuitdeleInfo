import os

from flask import Flask, make_response, render_template, send_file, send_from_directory, url_for
from . import db, auth


def create_app(test_config=None):
    # create and configure the app
    app = Flask(__name__, instance_relative_config=True, static_folder="static/build/static", template_folder="static/build")
    app.config.from_mapping(
        SECRET_KEY='dev',
        DATABASE=os.path.join(app.instance_path, 'flaskr.sqlite'),

    )
    db.init_app(app)
    app.register_blueprint(auth.bp)

    if test_config is None:
        # load the instance config, if it exists, when not testing
        app.config.from_pyfile('config.py', silent=True)
    else:
        # load the test config if passed in
        app.config.from_mapping(test_config)

    # ensure the instance folder exists
    try:
        os.makedirs(app.instance_path)
    except OSError:
        pass

    # a route where we will display a welcome message via an HTML template
    @app.route("/")
    def start():
        message = "Hello, World"
        return render_template('index.html')

    # a simple page that says hello
    @app.route('/hello')
    def hello():
        response = make_response('Hello from Flask!', 200)
        response.mimetype = "text/plain"
        return response

    @app.route('/register')
    def register():
        response = make_response('Hello from Flask!', 200)
        response.mimetype = "text/plain"
        return response

    return app
