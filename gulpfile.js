﻿var gulp = require('gulp');
var jshint = require('gulp-jshint');

gulp.task('default', function () {
    // place code for your default task here
    return gulp.src('./src/helloWorld/*.js')
        .pipe(jshint())
        .pipe(jshint.reporter('default'));
});

gulp.task('watch', function () {
    gulp.watch(['./src/helloWorld/*.js','gulpfile.js'],['default']);
});