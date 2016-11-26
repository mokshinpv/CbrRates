var excludeModules = [];
var includeModules = [
    '../libs/requirejs/require',
    'app'
];

module.exports = function (grunt) {
    'use strict';

    require('time-grunt')(grunt);

    var pkg = grunt.file.readJSON('package.json');
    grunt.initConfig({
        pkg: pkg,
        requirejs: {
            'cbr.build.ru': {
                options: {
                    optimize: 'uglify',
                    baseUrl: 'app',
                    mainConfigFile: 'app/app.js',
                    out: 'build/cbr.ru.js',
                    inlineText: true,
                    pragmas: {
                        build: true
                    },
                    locale: 'ru-ru',
                    include: includeModules,
                    exclude: excludeModules
                }
            },
            'cbr.dev.ru': {
                options: {
                    optimize: 'none',
                    baseUrl: 'app',
                    mainConfigFile: 'app/app.js',
                    out: 'build/cbr.ru.js',
                    inlineText: true,
                    pragmas: {
                        build: false
                    },
                    locale: 'ru-ru',
                    include: includeModules,
                    exclude: excludeModules
                }
            }
        },
        bower: {
            install: {
                options: {
                    copy: false,
                    layout: 'byComponent',
                    install: true,
                    verbose: false,
                    cleanTargetDir: false,
                    cleanBowerDir: false,
                    bowerOptions: {}
                }
            }
        },
        cssmin: {
            'styles': {
                files: {
                    'build/cbr.min.css': ['build/cbr.css']
                }
            }
        },
        concat: {
            'styles': {
                files: {
                    'build/cbr.css': [
                        'libs/bootstrap/dist/css/bootstrap.css'
                    ]
                }
            }
        },
        copy: {
            images: {
                files: [
                    { src: ['libs/bootstrap/dist/css/bootstrap.css.map'], dest: 'build/bootstrap.css.map' },
                    { src: ['libs/bootstrap/dist/css/bootstrap.css'], dest: 'build/bootstrap.css' }
                ]
            }
        },
        clean: {
            build: ['build']
        },
        jshint: {
            all: ['gruntfile.js', 'app/**/*.js'],
            options: {
                jshintrc: true
            }
        }
    });

    grunt.loadNpmTasks('grunt-bower-task');
    grunt.loadNpmTasks('grunt-contrib-requirejs');
    grunt.loadNpmTasks('grunt-contrib-concat');
    grunt.loadNpmTasks('grunt-contrib-cssmin');
    grunt.loadNpmTasks('grunt-contrib-copy');
    grunt.loadNpmTasks('grunt-contrib-clean');
    
    grunt.registerTask('dev', ['clean:build', 'bower', 'concat', 'cssmin', 'copy:images', 'requirejs:cbr.dev.ru']);
    grunt.registerTask('release', ['clean:build', 'bower', 'concat', 'cssmin', 'copy:images', 'requirejs:cbr.build.ru']);

    var target = grunt.option('target') || 'dev';
    if (target === 'release') {
        grunt.log.writeln('run app build in release mode');
        grunt.registerTask('default', 'release');
    } else {
        grunt.log.writeln('run app build in debug mode');
        grunt.registerTask('default', 'dev');
    }
};